using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField]private Toolbar toolbar;
    [SerializeField]private GameObject interactionToolTip;
    private void Awake()
    {
        if(Instance== null)
            Instance = this;       
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {ToggleInventory();}
        if(Input.GetKeyDown(KeyCode.Q))
        {
            toolbar.DropItem();
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
            interactionToolTip.GetComponent<CanvasGroup>().alpha = 0;
            return true;
        }
        return false;
    }
}
