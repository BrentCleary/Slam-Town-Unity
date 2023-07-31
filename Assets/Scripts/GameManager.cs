using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    private PlayerController playerController;

    public Button restartButton;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOverCheck();
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    void GameOverCheck()
    {
        if(playerController.gameOver)
        {
            restartButton.gameObject.SetActive(true);
        }
    }
}
