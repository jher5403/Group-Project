using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles sound effects. Pretty self explanitory.
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
        AudioSource source = Instantiate(soundEffectObj, spawnTransformer.position, Quaternion.identity);
        source.clip = soundClip;
        source.volume = volume;
        source.Play();

        float clipLength = source.clip.length;
        Destroy(source.gameObject, clipLength);

    }

}
