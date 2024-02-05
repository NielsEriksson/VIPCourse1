using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickUp : MonoBehaviour
{
    public static PlayerPickUp instance;
    public Transform holdingPos;
    private GameObject currentItem;
    [HideInInspector] public bool isHoldingItem;
    // Start is called before the first frame update
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
   public GameObject GetCurrentItem()
    {
        return currentItem;
    }
    public void PickUp(GameObject itemToPickUp) //this method allows to pick up a specific item 
    {
        if (!isHoldingItem)
        {
            itemToPickUp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            itemToPickUp.GetComponent<Rigidbody>().useGravity = false;
            itemToPickUp.GetComponent<Collider>().enabled = false;
            isHoldingItem = true;
            currentItem = itemToPickUp;
            currentItem.transform.parent = holdingPos.transform;
            currentItem.transform.localPosition = new Vector3(0,0,0);
            PlayerInteract.instance.RemoveOutline(currentItem);
        }
    }
    private void OnDropItem(InputValue value)
    {
        Debug.Log("dropping");
        if (isHoldingItem)
        {
            currentItem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            currentItem.GetComponent<Rigidbody>().useGravity = true;
            currentItem.GetComponent<Collider>().enabled = true;
            ReleaseItem();
        }
    }
    public void ReleaseItem()
    {
        isHoldingItem = false;
        currentItem.transform.parent = null;
        currentItem = null;
    }
    public void DestroyCarriedItem()
    {
        Destroy(currentItem);
        currentItem = null;
        isHoldingItem = false;
    }
}
