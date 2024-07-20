using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip mainMenuTrack;
    [SerializeField] private AudioClip buttonClickSoundFX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayMainMenuMusic();
    }

    private void PlayMainMenuMusic()
    {
        audioSource.clip = mainMenuTrack;
        audioSource.Play();
    }

    public void PlayButtonClickSoundFX()
    {
        audioSource.PlayOneShot(buttonClickSoundFX);
    }
}
