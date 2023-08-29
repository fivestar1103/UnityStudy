using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // rigidbody to be used for movement
    public float speed = 8f; // velocity
    void Start()
    {
        Application.targetFrameRate = 60;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // store the input every frame to ignore inertia
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        
        float xSpeed = xInput * speed;
        float zSpeed = yInput * speed;

        // allocate a new velocity every frame
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        playerRigidbody.velocity = newVelocity;
    }

    public void Die() // this method is called by the bullet that is hit
    {
        gameObject.SetActive(false);
    }
}
