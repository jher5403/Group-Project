using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script allows for an object to dynamically face another object. It also
 * contains logic to fire projectiles at objects too.
 * 
 * Sources: 
 * https://discussions.unity.com/t/2d-look-at-object-disappears/619335/8 (Aim logic)
 * https://stackoverflow.com/a/58192319 (Random fire logic)
 */
public class SAM : MonoBehaviour
{
    // Object that will rotate to aim at target.
    [SerializeField]
    public GameObject platform;

    // Where the shooter is aiming.
    [SerializeField]
    public GameObject target;

    // Thing that is shooting
    [SerializeField]
    public Weapon weapon;

    // Sound of projectile.
    [SerializeField]
    private AudioClip missileSound;

    /*
     * This is a coroutine. It is enabled at the start of the scene, and will randomly fire projectiles
     * every 3-15 seconds.
     */
    private IEnumerator randomFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 15));
            SoundEffectsManager.instance.PlaySound(missileSound, transform, 0.4f);
            weapon.Fire();
        }
    }

    // Start coroutine
    private void Start()
    {
        StartCoroutine(randomFire());
    }

    /*
     * Once the player object is destroyed, all coroutines (really just one)
     * are stopped. This means the SAM objects no longer fire.
     */
    void Update()
    {
        try
        {
            Vector2 current = platform.transform.position;
            Vector2 direction = (Vector2)target.transform.position - current;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            platform.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        } 
        catch (MissingReferenceException) {
            StopAllCoroutines();
        }
        
    }

}
