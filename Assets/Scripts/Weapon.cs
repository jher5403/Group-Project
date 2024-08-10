using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A weapon script. Creates new instances of projectile prefab. Projectile is also placeholder.
 * Currently, there is no way to manage the number of projectiles, futhermore, the inputs themselves
 * need to be adjusted for a held input. (For continious fire)
 * 
 * Source: https://www.youtube.com/watch?v=LqrAbEaDQzc
 */
public class Weapon : MonoBehaviour
{
    // Projectile speed.
    [SerializeField]
    public float projSpeed = 20f;

    // Projectile prefab reference
    [SerializeField]
    public GameObject projectilePrefab;

    // Point where projectiles are emitted
    [SerializeField]
    public Transform firePoint;

    // Fires projectile from firePoint. Uses projectile RigidBody to move.
    public void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * projSpeed, ForceMode2D.Impulse);

    }

}
