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
    public static PlayerInteract instance;
    public Transform interactSource;
    public float interactRange;
    private IInteractable objectToInteract;
    private GameObject objectToInteractGO;
    [SerializeField] CanvasGroup eInteract; //Interact tooltip UI gameObject
    [SerializeField] Material outlineMaterial;
    // Update is called once per frame
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    void LateUpdate()
    {
        Ray r = new Ray(interactSource.position, interactSource.forward);
        if(Physics.Raycast(r, out RaycastHit hitInfo,interactRange)) 
        {
            Debug.Log(hitInfo.collider.gameObject);
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                if (objectToInteractGO != null) RemoveOutline(objectToInteractGO);
                objectToInteract = interactObj;
                objectToInteractGO = hitInfo.collider.gameObject;
                eInteract.GetComponent<CanvasGroup>().alpha = 1;
                objectToInteract.SetInteractionMessage(eInteract.gameObject);
                SetOutline(objectToInteractGO);
                return;
            }
            else
            {
                if (objectToInteractGO != null)
                {
                    eInteract.GetComponent<CanvasGroup>().alpha = 0;
                    if (objectToInteractGO != null) RemoveOutline(objectToInteractGO);
                    objectToInteract = null;
                    objectToInteractGO = null;
                }
            }    
        }
        else
        {
            if (objectToInteractGO != null)
            {
                eInteract.GetComponent<CanvasGroup>().alpha = 0;
                if (objectToInteractGO != null) RemoveOutline(objectToInteractGO);
                objectToInteract = null;
                objectToInteractGO = null;
            }
        }
    }

    private void OnInteract(InputValue value)
    {
        if (objectToInteract!=null)
        {
            objectToInteract.Interact();
            objectToInteract = null;
            objectToInteractGO = null;
        }
    }

    public void SetOutline(GameObject go)
    {
        List<Material> materials = new List<Material>();
        materials.Add(go.GetComponent<Renderer>().material);
        materials.Add(outlineMaterial);
        go.GetComponent<Renderer>().SetMaterials(materials);
    }
    public void RemoveOutline(GameObject go)
    {
        List<Material> materials = new List<Material>();
        materials.Add(go.GetComponent<Renderer>().materials[0]);
        go.GetComponent<Renderer>().SetMaterials(materials);
    }
}
