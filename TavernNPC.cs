using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TavernNPC : NPC
{
    [SerializeField] private string[] animationStrings = { "sitting_01", "sitting_02", "sitting_03"};

    private void Start()
    {
        PlayRandomSittingAnimation();
    }

    private void PlayRandomSittingAnimation()
    {
        int randomNumber = Random.Range(1, animationStrings.Length);
        animator.Play(animationStrings[randomNumber]);
    }
}
