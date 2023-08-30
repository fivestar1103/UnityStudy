using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required to use the UI component
using UnityEngine.SceneManagement; // required to use the SceneManagement component 


public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // this object will just be turned on and off, thus declared as a simple GameObject not Text
    public Text timeText;
    public Text recordText;

    private float surviveTime;
    public bool isGameover;

    private void Start()
    {
        surviveTime = 0f;
        isGameover = false;
    }

    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + surviveTime.ToString("F2");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("GameScene");
                isGameover = false;
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");
        if (surviveTime > bestTime)
        {
            bestTime = Mathf.Round(surviveTime * 100f) / 100f;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            recordText.text = "NEW BEST TIME!";
        }
        else
        {
            recordText.text = "Best Time: " + bestTime;
        }
    }
}
