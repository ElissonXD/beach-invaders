using UnityEngine;

public class MusicManager : MonoBehaviour
{   
    private static MusicManager Instance;
    private AudioSource audioSource;
    public AudioClip backgroundMusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Instance.audioSource = GetComponent<AudioSource>();
            Instance.audioSource.volume = 0.15f;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (backgroundMusic != null)
        {
            PlayBackgroundMusic(false, backgroundMusic);
        }
    }
    public static void PlayBackgroundMusic(bool resetSong, AudioClip audioClip = null)
    {
        if (audioClip != null)
        {
            Instance.audioSource.clip = audioClip;
            Instance.audioSource.Play();
        }
        else if (Instance.audioSource.clip != null)
        {
            if (resetSong)
            {
                Instance.audioSource.Stop();
            }
            Instance.audioSource.Play();
        }
    }
    public static void PauseBackgroundMusic()
    {
        Instance.audioSource.Pause();
    }
}
