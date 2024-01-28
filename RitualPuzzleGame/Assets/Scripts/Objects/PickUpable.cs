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
        eInteract.GetComponentInChildren<TMP_Text>().text = "Pick Up";
    }


}
