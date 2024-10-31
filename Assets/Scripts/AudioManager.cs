using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private int sceneIndex;

    [Header("---Audio Source---")]
    [SerializeField]
    AudioSource musicSource;
    [SerializeField]
    AudioSource SFXSource;
    [SerializeField]
    AudioSource Walk;

    [Header("---Audio Clip---")]
    public AudioClip mainMenu;
    public AudioClip Entrance;
    public AudioClip Level;
    public AudioClip zombieDeath;
    public AudioClip goblinDeath;
    public AudioClip servantDeath;
    public AudioClip coinAdded;
    public AudioClip Button;
    public AudioClip zombieCoin;
    public AudioClip Walking;
    [SerializeField]
    public AudioClip[] Shoots;
    public AudioClip levelFailed;
    public AudioClip levelClear;
    [SerializeField]
    public AudioClip[] meatSounds;
    public AudioClip enemyWall;
    public AudioClip middleWall;
    public AudioClip marketSwipe;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        musicSource.clip = mainMenu;
        musicSource.Play();
    }
    public void ChangeSceneMusic(int a)
    {
        if(a == 1)
        {
            musicSource.Stop();
            musicSource.clip = Entrance;
            musicSource.Play();
        }
        else if (a == 2)
        {
            musicSource.Stop();
            musicSource.clip = Level;
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void OnWalk(AudioClip clip)
    {
        Walk.clip = Walking;
        Walk.Play();
    }
    public void OffWalk(AudioClip clip)
    {
        Walk.Stop();
    }

    public void PlayShotSound(AudioClip clip, int index)
    {
        SFXSource.PlayOneShot(clip);
    }
    
}
