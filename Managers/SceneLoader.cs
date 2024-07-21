using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    [SerializeField] private string bootstrapperSceneName = "000_bootstrapper";
    [SerializeField] private string mainMenuSceneName = "001_main_menu";
    [SerializeField] private string townSceneName = "002_town";
    [SerializeField] private string merchantSceneName = "test_merchant";
    [SerializeField] private string governorSceneName = "test_governor";
    [SerializeField] private string tavernSceneName = "003_tavern";
    [SerializeField] private string shipwrightSceneName = "test_shipwright";
    [SerializeField] private string testTownSceneName = "test_town";

    private Scene bootstrapperScene;
    private Scene mainMenuScene;
    private Scene townScene;
    private Scene merchantScene;
    private Scene governorScene;
    private Scene tavernScene;
    private Scene shipwrightScene;
    private Scene testTownScene;

    private Scene previousScene;
    private Scene currentScene;

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
        bootstrapperScene = SceneManager.GetSceneByName(bootstrapperSceneName);
        mainMenuScene = SceneManager.GetSceneByName(mainMenuSceneName);
        townScene = SceneManager.GetSceneByName(townSceneName);
        merchantScene = SceneManager.GetSceneByName(merchantSceneName);
        governorScene = SceneManager.GetSceneByName(governorSceneName);
        tavernScene = SceneManager.GetSceneByName(tavernSceneName);
        shipwrightScene = SceneManager.GetSceneByName(shipwrightSceneName);
        testTownScene = SceneManager.GetSceneByName(testTownSceneName);

        StartCoroutine(LoadSceneAsyncAdditively(mainMenuSceneName, scene => mainMenuScene = scene));
    }

    public IEnumerator LoadSceneAsyncAdditively(string sceneName, System.Action<Scene> onLoaded)
    {
        // Unload previous scene if there is one
        if (currentScene.IsValid())
        {
            UnloadScene(currentScene);
            Debug.Log("SCENE UNLOADED: " +  currentScene);
        }

        var asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        if (asyncOperation == null)
        {
            Debug.LogError($"Scene {sceneName} could not be loaded.");
            yield break;
        }

        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        Scene loadedScene = SceneManager.GetSceneByName(sceneName);
        if (loadedScene.IsValid())
        {
            previousScene = currentScene; // Keep track of the old scene
            currentScene = loadedScene;   // Update current scene
            onLoaded?.Invoke(loadedScene);
            SetActiveScene(loadedScene);
            Debug.Log("LOADED SCENE IS " + loadedScene.name);
        }
        else
        {
            Debug.LogError($"Scene {sceneName} is not valid.");
        }
    }

    public void UnloadScene(Scene scene)
    {
        if (scene.IsValid() && scene.isLoaded)
        {
            SceneManager.UnloadSceneAsync(scene);
        }
    }

    public void SetActiveScene(Scene scene)
    {
        if (scene.IsValid() && scene.isLoaded)
        {
            PlayerUIManager.Instance.loadingScreen.SetActive(false);
            SceneManager.SetActiveScene(scene);
        }
    }
}
