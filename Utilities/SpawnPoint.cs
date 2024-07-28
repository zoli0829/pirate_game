using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    protected void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        boxCollider = GetComponentInChildren<BoxCollider>();
    }

    protected void Start()
    {
        meshRenderer.enabled = false;
        boxCollider.enabled = false;
    }
}
