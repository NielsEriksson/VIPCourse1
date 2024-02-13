using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpable : MonoBehaviour,IInteractable
{
   
    public virtual void Interact()
    {
        PlayerPickUp.instance.PickUp(gameObject);
    }

    public virtual void SetInteractionMessage(GameObject eInteract)
    {
        
        eInteract.GetComponentInChildren<TMP_Text>().text = "Pick Up";
    }


}
