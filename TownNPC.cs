using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownNPC : NPC
{
    [SerializeField] private string sitting_01 = "sitting_01";

    private void Start()
    {
        animator.Play(sitting_01);
    }
}
