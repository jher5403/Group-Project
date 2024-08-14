using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script handles the game over screen upon acheiving a win or loss condition.
 * These conditions are either destruction of the player object or running down the timer.
 * 
 * The individual menus Will allow the game scene to reset or navigate to the main menu.
 * Game over UI should be remain inactive until triggered.
 * 
 * Source: https://www.youtube.com/watch?v=pKFtyaAPzYo
 */
public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI; // Loss screen
    public GameObject gameWinUI; // Win screen
    private bool activeMenu = false; // Will prevent menu overlapping.

    public void GameWin()
    {
        if (!activeMenu)
        {
            Time.timeScale = 0; // Pause game
            gameWinUI.SetActive(true); // Activate menu
            activeMenu = true; // Toggle flag to prevent overlap.
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

    // Resets game scene and unpauses the game
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Unpauses and then transitions the game.
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }

}
