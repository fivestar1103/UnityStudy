using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour {
   public AudioClip deathClip; // 사망시 재생할 오디오 클립
   public float jumpForce = 700f; // 점프 힘

   private int jumpCount = 0; // 누적 점프 횟수
   private bool isGrounded = true; // 바닥에 닿았는지 나타냄
   private bool isDead = false; // 사망 상태

   private Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트
   private Animator animator; // 사용할 애니메이터 컴포넌트
   private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트

   private void Start()
   {
       playerRigidbody = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
       playerAudio = GetComponent<AudioSource>();
   }

   private void Update() {
       // 사용자 입력을 감지하고 점프하는 처리
       if (isDead)
       {
           return;
       }

       if (Input.GetMouseButtonDown(0) && jumpCount < 2)
       {
           jumpCount++;
           playerRigidbody.velocity = Vector2.zero;
           playerRigidbody.AddForce(new Vector2(0,jumpForce));
           playerAudio.Play();
       }
       // by doing this, player jumps higher if mouse click is held longer
       else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
       {
           playerRigidbody.velocity /= 2f; // slow down by 50% on mouse release when jumping up
       }
       
       animator.SetBool("Grounded", isGrounded);
   }

   private void Die() {
       // 사망 처리
       // the SetTrigger method changes the field to True than back to False instantly
       animator.SetTrigger("Die");
       
       // change the audio allocated to audio source to deathClip
       playerAudio.clip = deathClip;
       playerAudio.Play();
       
       playerRigidbody.velocity = Vector2.zero;
       isDead = true;
       
       // easily call the gameManager's method by using the singleton design pattern
       GameManager.instance.OnPlayerDead();
   }

   private void OnTriggerEnter2D(Collider2D other) {
       // 트리거 콜라이더를 가진 장애물과의 충돌을 감지
       if (other.tag == "Dead" && !isDead)
       {
           Die(); // call Die() if not dead yet when touching the Deadzone
       }
   }

   private void OnCollisionEnter2D(Collision2D collision) {
       // 바닥에 닿았음을 감지하는 처리
       // Collision type data stores the contact points
       // the array saves the contact points
       // so the contacts[0].normal.y means the y value of the normal vector of the first contact point
       // if the y value is near 1, it means that the surface is not steep
       // y value greater than 0.7 means a not too steep surface facing upwards
       // this is necessary to avoid wrong collisions against cliffs or ceilings as floors
       if (collision.contacts[0].normal.y > 0.7f)
       {
           isGrounded = true;
           // reset the jumpCount if it touches the ground
           jumpCount = 0;
       }
   }

   private void OnCollisionExit2D(Collision2D collision) {
       // 바닥에서 벗어났음을 감지하는 처리
       isGrounded = false;
   }
}