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
    public GameObject gameWinUI;
    private bool activeMenu = false;

    public void GameWin()
    {
        if (!activeMenu)
        {
            Time.timeScale = 0;
            gameWinUI.SetActive(true);
            activeMenu = true;
        }
    }

    public void GameOver() 
    {
        if (!activeMenu)
        {
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
            activeMenu = true;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }

}
