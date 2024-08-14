using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * Timer logic for win condition. Transitions to win screen after timer reaches 0.
 * Also responsible for updating the timer UI itself.
 * 
 * Source: https://www.youtube.com/watch?v=POq1i8FyRyQ
 */
public class TimerLogic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] float remainingTime;

    public GameOverManager gameOverManager;

    // Timer logic.
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime; // Deincrement every tick.
        } 
        else if (remainingTime <= 0)
        {
            remainingTime = 0; // Display 0 when timer is 0 or less.
            gameOverManager.GameWin(); // Transition to win screen.
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
