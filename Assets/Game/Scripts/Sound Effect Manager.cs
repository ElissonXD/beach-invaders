using UnityEngine;
using System.Collections.Generic;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager Instance;
    private SoundEffectLibrary soundEffectLibrary;
    private AudioSource audioSource;

    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            soundEffectLibrary = GetComponent<SoundEffectLibrary>();
            audioSource.volume = 0.15f;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void Play(string soundName)
    {
        AudioClip clip = Instance.soundEffectLibrary.GetRandomClip(soundName);
        if (clip != null)
        {
            Instance.audioSource.PlayOneShot(clip);
        }
    }
}
