using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpable : MonoBehaviour,IInteractable
{
   
    public void Interact()
    {
        PlayerPickUp.instance.PickUp(gameObject);
    }

    public void SetInteractionMessage(GameObject eInteract)
    {
        if(PlayerPickUp.instance!=null && PlayerPickUp.instance.isHoldingItem)
        {
            eInteract.GetComponent<CanvasGroup>().alpha = 0;
            return;
        }
        eInteract.GetComponentInChildren<TMP_Text>().text = "Pick Up";
    }


}
