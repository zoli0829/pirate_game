using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemSingleton : MonoBehaviour
{
    private static EventSystemSingleton Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }
}
