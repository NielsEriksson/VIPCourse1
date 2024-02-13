using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSensor : MonoBehaviour
{

    [SerializeField] private Material completeMaterial;

    [SerializeField] private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    public void Complete()
    {
        meshRenderer.materials[1] = completeMaterial;
    }
}
