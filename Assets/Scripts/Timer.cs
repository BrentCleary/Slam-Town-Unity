using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private PlayerController playerControllerScript;



    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!playerControllerScript.gameOver)
        {            
            float t = Time.time - startTime;

            string seconds = (t).ToString("f1");

            timerText.text = seconds;
        }
    }
}
