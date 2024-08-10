using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script handles the game over screen upon acheiving a loss condition (Destruction of player object).
 * Will allow the game scene to reset or navigate to the main menu.
 * Game over UI should be remain inactive until triggered.
 * 
 * Source: https://www.youtube.com/watch?v=pKFtyaAPzYo
 */
public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GameOver() 
    {
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

}
