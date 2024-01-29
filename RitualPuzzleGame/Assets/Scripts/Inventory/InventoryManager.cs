using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField]private Toolbar toolbar;
    private void Awake()
    {
        if(Instance== null)
            Instance = this;       
    }
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
    public bool AddToInv(CollectibleObject obj)
    {
        int avail = toolbar.CheckAvailible();
        if(avail!=0)
        {
            toolbar.SetItem(avail, obj);
            return true;
        }
        return false;
    }
}
