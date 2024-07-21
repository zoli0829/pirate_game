
using StarterAssets;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    [Header("Scenes")]
    //[SerializeField] private string bootstrapperSceneName = "000_bootstrapper";
    [SerializeField] private string mainMenuSceneName = "001_main_menu";
    //[SerializeField] private string townSceneName = "002_town";
    //[SerializeField] private string merchantSceneName = "test_merchant";
    //[SerializeField] private string governorSceneName = "test_governor";
    //[SerializeField] private string tavernSceneName = "003_tavern";
    //[SerializeField] private string shipwrightSceneName = "test_shipwright";
    [SerializeField] private string testTownSceneName = "test_town";

    [Header("Loading Screen Game Objects")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingSlider;

    [Header("Supporting Game Objects")]
    //ADDED A CAMERA SO IT WONT DISPLAY NO CAMERAS ACTIVE
    [SerializeField] private GameObject bootstrapperCamera;
    public Vector3 tavernSpawnPoint;
    public Vector3 merchantSpawnPoint;
    public Vector3 shipwrightSpawnPoint;
    public Vector3 townhallSpawnPoint;
    public Vector3 dockSpawnPoint;
    public Vector3 indoorSpawnPoint;

    [SerializeField] private ThirdPersonController player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }    
        else
        {
            Destroy(gameObject);
        }

        bootstrapperCamera = GameObject.Find("Bootstrapper Camera");
    }

    private void Start()
    {
        // ALWAYS START WITH LOADING THE MAIN MENU SCENE FROM THE BOOTSTRAPPER
        LoadSceneAdditiveAsync(mainMenuSceneName);
    }

    // FUNCTION TO LOAD A SCENE ADDITIVELY AND ASYNC
    public void LoadSceneAdditiveAsync(string sceneName)
    {
        StartCoroutine(LoadSceneAdditiveAsyncCoroutine(sceneName));
    }

    // USE THIS METHOD WHEN ENTERING OR LEAVING TAVERNS MERCHANTS ETC
    public void LoadSceneAdditivelyAndRemovePreviousScene(string sceneToLoad, string sceneToUnload)
    {
        // SCENE TO UNLOAD
        // FIRST I NEED TO UNLOAD THE SCENE OTHERWISE IT INSTANTIATES A 2ND PLAYER RIG AND MESSESS UP THE CONTROLS
        UnloadScene(sceneToUnload);

        // SCENE TO LOAD
        LoadSceneAdditiveAsync(sceneToLoad);
    }

    private IEnumerator LoadSceneAdditiveAsyncCoroutine(string sceneName)
    {
        // SETTING THE LOADING SCREEN CANVAS ACTIVE
        loadingScreen.SetActive(true);
        //SETTING THE CAMERA TO ACTIVE FOR THE LOADING SCREEN TO NOT BUG OUT
        bootstrapperCamera.SetActive(true);

        // START LOADING THE SCENE
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        // WAIT UNTIL THE ASYNC SCENE FULLY LOADS, MEANWHILE UPDATE THE LOADING BAR
        while (!asyncLoad.isDone)
        {
            float progressValue = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }

        // SET THE SPAWN POINTS
        FindSpawnPointsInTheScene();

        // GET THE PLAYER
        FindPlayer();

        // SETTING THE LOADING SCREEN CANVAS INACTIVE
        loadingScreen.SetActive(false);
        // DEACTIVATING THE CAMERA
        bootstrapperCamera.SetActive(false);

        // GRABBING THE SCENE FROM STRING
        Scene sceneToSetActive = SceneManager.GetSceneByName(sceneName);

        // SETTING IT AS THE ACTIVE SCENE
        SceneManager.SetActiveScene(sceneToSetActive);

        if (bootstrapperCamera.activeSelf)
        {
            // DISABLE THE SUPPORT CAMERA
            bootstrapperCamera.SetActive(false);
        }
    }

    public void StartNewGame()
    {
        LoadSceneAdditiveAsync(testTownSceneName);
        UnloadScene(mainMenuSceneName);
    }

    public void UnloadScene(string sceneToUnload)
    {
        SceneManager.UnloadSceneAsync(sceneToUnload);
    }

    // TRIES TO FIND THE SPAWN POINTS IN THE SCENE IF THERE ARE ANY IF THERE ARENT THEN IT USES THE PREVIOUSLY SAVED ONES
    private void FindSpawnPointsInTheScene()
    {
        TavernSpawnPoint foundTavernSpawnPoint = FindFirstObjectByType<TavernSpawnPoint>();
        if(foundTavernSpawnPoint != null)
            tavernSpawnPoint = foundTavernSpawnPoint.transform.position;

        MerchantSpawnPoint foundMerchantSpawnPoint = FindFirstObjectByType<MerchantSpawnPoint>();
        if (foundMerchantSpawnPoint != null)
            merchantSpawnPoint = foundMerchantSpawnPoint.transform.position;

        ShipwrightSpawnPoint foundShipwrightSpawnPoint = FindFirstObjectByType<ShipwrightSpawnPoint>();
        if (foundShipwrightSpawnPoint != null)
            shipwrightSpawnPoint = foundShipwrightSpawnPoint.transform.position;

        TownhallSpawnPoint foundTownhallSpawnPoint = FindFirstObjectByType<TownhallSpawnPoint>();
        if (foundTownhallSpawnPoint != null)
            townhallSpawnPoint = foundTownhallSpawnPoint.transform.position;

        DockSpawnPoint foundDockSpawnPoint = FindFirstObjectByType<DockSpawnPoint>();
        if (foundDockSpawnPoint != null)
            dockSpawnPoint = foundDockSpawnPoint.transform.position;

        IndoorSpawnPoint foundIndoorSpawnPoint = FindFirstObjectByType<IndoorSpawnPoint>();
        if( foundIndoorSpawnPoint != null)
            indoorSpawnPoint = foundIndoorSpawnPoint.transform.position;
    }

    public void FindPlayer() 
    {
        ThirdPersonController foundPlayer = FindFirstObjectByType<ThirdPersonController>();
        if (foundPlayer != null)
            player = foundPlayer;
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
