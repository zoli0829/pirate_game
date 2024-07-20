using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string testTownSceneName = "test_town";

    private Scene bootstrapperScene;
    private Scene mainMenuScene;
    private Scene townScene;
    private Scene merchantScene;
    private Scene governorScene;
    private Scene tavernScene;
    private Scene shipwrightScene;
    private Scene testTownScene;

    public void LoadNewGame()
    {
        StartCoroutine(SceneLoader.Instance.LoadSceneAsyncAdditively(testTownSceneName, scene => testTownScene = scene));
    }
}
