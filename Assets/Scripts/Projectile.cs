using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Projectile object. Will destroy itself either on collison or after 2 seconds
 * 
 * Projectile Source: https://www.youtube.com/watch?v=LqrAbEaDQzc
 * Collision Logic Source: https://www.youtube.com/watch?v=Bc9lmHjqLZc
 */
public class Projectile : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //string objName = collision.gameObject.name;
        //Debug.Log($"Projectile has hit {objName}");
        Destroy(gameObject);
    }

}
