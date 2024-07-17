using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCRandomizer : MonoBehaviour
{
    [SerializeField] private NPC[] characters;

    private void Awake()
    {
        characters = GetComponentsInChildren<NPC>();
    }

    private void Start()
    {
        ChooseRandomNPCCharacter();
    }

    private void ChooseRandomNPCCharacter()
    {
        // Check if there are any characters
        if (characters.Length == 0) return; 

        int randomNumber = Random.Range(0, characters.Length);

        foreach (NPC character in characters)
        {
            character.gameObject.SetActive(false);
        }
        characters[randomNumber].gameObject.SetActive(true);
    }
}
