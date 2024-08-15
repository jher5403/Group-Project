using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles sound effects. Instantiated when an sound is played.
 * Requires a direct reference to an audio clip when calling.
 * 
 * Source: https://www.youtube.com/watch?v=DU7cgVsU2rM
 */
public class SoundEffectsManager : MonoBehaviour
{
    public static SoundEffectsManager instance;
    [SerializeField] private AudioSource soundEffectObj;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySound(AudioClip soundClip, Transform spawnTransformer, float volume)
    {
        AudioSource source = Instantiate(soundEffectObj, spawnTransformer.position, Quaternion.identity); // Create sound manager
        source.clip = soundClip; // Reference to sound clip
        source.volume = volume; // Sets volumes
        source.Play(); // Plays clip

        // Destroys instance after reaching end of sound.
        float clipLength = source.clip.length;
        Destroy(source.gameObject, clipLength);

    }

}
