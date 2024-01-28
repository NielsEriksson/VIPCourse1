using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

interface IInteractable
{
    public void Interact(); //any object that can be interacted with in anyway will need to inherit IInteractable and have this method
    public void SetInteractionMessage(GameObject eInteract); //Sets what text should show in the interaction tooltip
}
public class PlayerInteract : MonoBehaviour
{
    public Transform interactSource;
    public float interactRange;
    private IInteractable objectToInteract;
    [SerializeField] GameObject eInteract; //Interact tooltip UI gameObject
    // Update is called once per frame
    void LateUpdate()
    {
        Ray r = new Ray(interactSource.position, interactSource.forward);
        if(Physics.Raycast(r, out RaycastHit hitInfo,interactRange)) 
        {
            if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                objectToInteract = interactObj;
                if(!eInteract.activeInHierarchy) eInteract.SetActive(true);
            }
            else
            {
                if(eInteract.activeInHierarchy)
                    eInteract.SetActive(false);
            }    
        }
    }
    private void OnInteract(InputValue value)
    {
        if (objectToInteract!=null)
        {
            objectToInteract.Interact();
        }
    }
}
