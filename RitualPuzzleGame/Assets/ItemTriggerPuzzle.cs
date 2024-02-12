using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemTriggerPuzzle : MonoBehaviour
{
    [SerializeField] private string objName;
    [SerializeField] private GameObject bookObject;
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
        Instantiate(bookObject, gameObject.transform.position, Quaternion.identity);
    }
}
