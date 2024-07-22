using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Tavern Audio Manager")]
    [SerializeField] private GameObject tavernAudioManager;
    public bool isTavernAudioManagerActive = false;

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
    }

    private void Start()
    {
        PlayMainMenuMusic();
    }

    public void PlayMainMenuMusic()
    {
        audioSource.clip = mainMenuTrack;
        if (audioSource.clip == null) return;
        audioSource.Play();
    }

    public void PlayButtonClickSoundFX()
    {
        audioSource.PlayOneShot(buttonClickSoundFX);
    }

    public void FadeOutAndStop(float duration)
    {
        StartCoroutine(FadeOutCoroutine(duration));
    }

    private IEnumerator FadeOutCoroutine(float duration)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume; // Reset volume for the next play
    }

    public void EnableTavernAudioManager()
    {
        tavernAudioManager.gameObject.SetActive(true);
        isTavernAudioManagerActive = true;

    }

    public void DisableTavernAudioManager()
    {
        tavernAudioManager.gameObject.SetActive(false);
        isTavernAudioManagerActive = false;
    }
}
