using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager Instance { get; private set; }

    // DECLARING UI ELEMENTS
    public GameObject interactionPrompt;
    public TextMeshProUGUI interactionText;
    public GameObject loadingScreen;
    public Slider loadingSlider;

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
        FindUIElements();
    }

    private void Start()
    {
        // SETTING THEM INACTIVE
        interactionPrompt.SetActive(false);
        loadingScreen.SetActive(false);
    }

    private void FindUIElements()
    {
        // FINDING AND CACHING THESE ELEMENTS
        interactionPrompt = GameObject.Find("Interaction Prompt");
        interactionText = GameObject.Find("Interaction Text").GetComponent<TextMeshProUGUI>();
        loadingScreen = GameObject.Find("LoadingScreenCanvas");
        loadingSlider = GameObject.Find("LoadingScreenSlider").GetComponent<Slider>();
    }
}
