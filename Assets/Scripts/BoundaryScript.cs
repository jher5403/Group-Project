/*
 * This script sets the positional boundary for a given object at the edges of the camera.
 * Keep in mind, that the object might have some clipping issues when it reaches the edge of the screen.
 * Implement an offset if you want to deal with it.
 * 
 * Source: https://www.youtube.com/watch?v=ailbszpt_AI
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private Vector2 screenBounds; // Position of bounds

    // Sets boundary of object to screen size.
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Updates position of game object.
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1, screenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y);
        transform.position = viewPos;
    }

}
