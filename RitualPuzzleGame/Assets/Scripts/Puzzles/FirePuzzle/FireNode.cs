using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireNode : MonoBehaviour, IInteractable
{
    private float rotationDuration;

    Coroutine coroutine;

    public int rotationIndex;

    private void Start()
    {
        rotationDuration = 1f;
        rotationIndex = (int)(transform.localEulerAngles.y / 45f);
    }



    public void Rotate()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(RotateObject());
        }
        
    }

    public void Move()
    {

    }

    IEnumerator RotateObject()
    {
        float elapsedTime = 0f;

        Quaternion startRotation = transform.rotation;

        // Calculate the target rotation 45 degrees from the current rotation
        Quaternion targetRotation = startRotation * Quaternion.Euler(0f, 45f, 0f);

        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object reaches the exact target rotation
        transform.rotation = targetRotation;
        coroutine = null;

        Debug.Log("Rotation completed!");
    }

    public void Interact()
    {
        Rotate();
    }

    public void SetInteractionMessage(GameObject eInteract)
    {
        eInteract.GetComponentInChildren<TMP_Text>().text = "Rotate";
    }
}
