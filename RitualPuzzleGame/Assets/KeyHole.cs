using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyHole : MonoBehaviour, IInteractable
{
    public int correctKeyID;
    [HideInInspector] public bool correctKeyIn;
    [HideInInspector] public GameObject currentKey;
    [SerializeField] Vector3 KeyPos;
    [SerializeField] Vector3 KeyRot;
    public void Interact()
    {
        if (PlayerPickUp.instance.GetCurrentItem() == null) { return; }
        TryKey(PlayerPickUp.instance.GetCurrentItem());
    }

    public void SetInteractionMessage(GameObject eInteract)
    {
        eInteract.GetComponentInChildren<TMP_Text>().text = "Interact";
    }

    public void TryKey(GameObject key)
    {
        if (key.GetComponent<PuzzleKey>() == null) return;
        currentKey = key;
        PlaceKeyInHole(key);
        if (key.GetComponent<PuzzleKey>().keyID != correctKeyID)
        {
            StartCoroutine(ReleaseKey());
        }
        else
        {
          correctKeyIn = true;
          if(KeyPuzzleSolver.instance.CheckPuzzle())
            {
                KeyPuzzleSolver.instance.CompletePuzzle();
            }
        }

    }

    public void PlaceKeyInHole(GameObject key)
    {
        PlayerPickUp.instance.ReleaseItem();
        currentKey.GetComponent<Collider>().enabled = false;    
        currentKey.transform.parent = transform;
        currentKey.transform.localPosition = KeyPos;
        //currentKey.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        currentKey.transform.localEulerAngles = KeyRot;
    }

    public IEnumerator ReleaseKey()
    {
        yield return new WaitForSeconds(1);
        currentKey.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        currentKey.GetComponent<Collider>().enabled = true;
        currentKey.transform.parent = null;
        currentKey.GetComponent<Rigidbody>().useGravity = true;
        currentKey.GetComponent<Rigidbody>().AddForce(currentKey.transform.up*-2.5f, ForceMode.Impulse);
        currentKey = null;
        yield break;
    }
}
