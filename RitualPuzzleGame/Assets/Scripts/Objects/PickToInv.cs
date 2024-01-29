using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickToInv : PickUpable
{
    private InventoryManager invm;
    private void Start()
    {
        invm = InventoryManager.Instance;
    }
    public override void Interact()
    {
        if(invm.AddToInv(gameObject.GetComponent<CollectibleObject>()))
        {           
            Destroy(gameObject);
        }
    }
    public override void SetInteractionMessage(GameObject eInteract)
    {
        if (PlayerPickUp.instance != null && PlayerPickUp.instance.isHoldingItem)
        {
            eInteract.GetComponent<CanvasGroup>().alpha = 0;
            return;
        }
        eInteract.GetComponentInChildren<TMP_Text>().text = "Add to Inventory";
    }
}
