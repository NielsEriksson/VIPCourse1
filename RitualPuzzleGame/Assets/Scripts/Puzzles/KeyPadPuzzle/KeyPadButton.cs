using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class KeyPadButton : MonoBehaviour, IInteractable
{
    public int buttonIndex;
    public bool pressed;

    [SerializeField] private float pressDistance, speed;
    private Vector3 startPosition, pressedPosition;

    Coroutine movement;

    [SerializeField] private KeyPad keyPad;

    private void Start()
    {
        startPosition = transform.position;
        pressedPosition = transform.position + pressDistance * transform.forward;
    }


    public void Press()
    {
        if (!pressed)
        {
            if (movement != null)
            {
                StopCoroutine(movement);
                movement = null;
            }
            MoveIn();
        }
    }

    public void MoveIn()
    {
        if (movement == null)
        {
            movement = StartCoroutine(MoveObject(startPosition, pressedPosition));
            pressed = true;
        }
        
    }

    public void ResetButton()
    {
        if (movement != null)
        {
            StopCoroutine(movement);
            movement = null;
        }

        MoveOut();
    }

    public void MoveOut()
    {
        if (movement == null)
        {
            movement = StartCoroutine(MoveObject(pressedPosition, startPosition));
            pressed = false;
        }
        
    }
    IEnumerator MoveObject(Vector3 start, Vector3 end)
    {
        float distance = Vector3.Distance(start, end);

        while (distance > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, end, speed * Time.deltaTime);
            distance = Vector3.Distance(transform.position, end);
            yield return null;
        }
        transform.position = end;
        if (start == startPosition)
        {
            keyPad.AddIndex(buttonIndex);
        }
        
    }

    public void Interact()
    {
        Press();
    }

    public void SetInteractionMessage(GameObject eInteract)
    {
        eInteract.GetComponentInChildren<TMP_Text>().text = "Press";
    }
}
