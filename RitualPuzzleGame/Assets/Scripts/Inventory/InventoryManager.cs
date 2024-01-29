using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{   
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }
    private void ToggleInventory()
    {
        GameObject gOb = gameObject.transform.GetChild(0).gameObject;
        gOb.SetActive(!gOb.activeSelf);
    }
}
