using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    protected Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }
}
