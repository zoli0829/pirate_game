using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : Interactable
{
    [SerializeField] private string levelToLoadString;
    private Scene sceneToLoad;

    private void Start()
    {
        sceneToLoad = SceneManager.GetSceneByName(levelToLoadString);
    }

    public override void Interact()
    {
        LoadLevel(levelToLoadString);
    }

    public override void ShowPrompt(bool show)
    {
        base.ShowPrompt(show);
    }

    public void LoadLevel(string levelToLoad)
    {
        PlayerUIManager.Instance.loadingScreen.SetActive(true);

        StartCoroutine(SceneLoader.Instance.LoadSceneAsyncAdditively(levelToLoad, scene => sceneToLoad = scene));
    }
}
