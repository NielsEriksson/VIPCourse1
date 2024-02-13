using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSensor : MonoBehaviour
{

    [SerializeField] private Material completeMaterial;

    [SerializeField] private MeshRenderer meshRenderer;

    [SerializeField] private BoxCollider bookCollider;

    private void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        bookCollider.enabled = false;
    }

    public void Complete()
    {
        meshRenderer.materials[1] = completeMaterial;
        bookCollider.enabled = true;
    }
}
