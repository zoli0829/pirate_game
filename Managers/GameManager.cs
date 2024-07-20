using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

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
    public void ExitGame()
    {
        Application.Quit();

        // If running in the Unity editor, stop play mode (this will not be included in the build)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
