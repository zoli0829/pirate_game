using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : Interactable
{
    [SerializeField] private string levelToLoadString;
    [SerializeField] private string levelToUnloadString;
    [SerializeField] private string whereToSpawn;

    public override void Interact()
    {
        LoadLevel(levelToLoadString, levelToUnloadString);
    }

    public override void ShowPrompt(bool show)
    {
        base.ShowPrompt(show);
    }

    public void LoadLevel(string levelToLoad, string levelToUnload)
    {
        GameManager.Instance.LoadSceneAdditivelyAndRemovePreviousScene(levelToLoad, levelToUnload);
        ShowPrompt(false);
    }
}
