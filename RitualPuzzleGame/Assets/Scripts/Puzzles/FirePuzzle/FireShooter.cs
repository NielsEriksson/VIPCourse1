using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireShooter : MonoBehaviour, IInteractable
{
    private float rotationDuration;

    Coroutine coroutine;

    public GameObject particle;

    private void Start()
    {
        rotationDuration = 3f;
    }

    public void SpawnLightLeader()
    {
        Instantiate(particle, transform.position, transform.rotation, transform);
    }


    public void Interact()
    {
        SpawnLightLeader();
    }

    public void SetInteractionMessage(GameObject eInteract)
    {
        eInteract.GetComponentInChildren<TMP_Text>().text = "Start";
    }
}
