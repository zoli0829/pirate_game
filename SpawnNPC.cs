using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnNPC : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject npcToSpawn;

    [SerializeField] private int randomNumberToRoll = 5;

    private void Start()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        int randomNumber = Random.Range(0, 11);

        if (randomNumber < randomNumberToRoll) return;

        if (spawnPosition == null) return;

        if (npcToSpawn != null)
        {
            Instantiate(npcToSpawn, spawnPosition);
        }
    }
}
