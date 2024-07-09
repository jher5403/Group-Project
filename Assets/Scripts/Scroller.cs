/*
 * Moves the texture of an quad in a defined direction and speed.
 * Does not actually move the object itself.
 * 
 * Ensure that the texture you're using has its wrap set to repeat.
 * Source: https://www.youtube.com/watch?v=Wz3nbQPYwss
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField]
    [Range(-2f, 2f)]
    public float speed;

    [SerializeField]
    private Renderer bgRenderer;

    [SerializeField]
    private Direction direction = Direction.Vertical;
    private Vector2 vectorDirection;

    // Update is called once per frame
    void Update()
    {
        setDirection();
        bgRenderer.material.mainTextureOffset += vectorDirection;
    }

    enum Direction
    {
        Vertical,
        Horizontal
    }

    public void setDirection()
    {
        switch (direction)
        {
            case Direction.Vertical:
                vectorDirection = new Vector2(0, speed * Time.deltaTime);
                break;

            case Direction.Horizontal:
                vectorDirection = new Vector2(speed * Time.deltaTime, 0);
                break;
            
        }
    }
}
