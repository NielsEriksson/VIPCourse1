using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTriggerPuzzle : MonoBehaviour
{
    [SerializeField] private string objName;
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(other.gameObject.name);
        if(other.gameObject.name ==(objName + "(Clone)"))
        {            
            Destroy(other.gameObject);
            TriggerEvent();
        }
    }
    private void TriggerEvent()
    {
        Debug.Log("CubeEnter");
    }
}
