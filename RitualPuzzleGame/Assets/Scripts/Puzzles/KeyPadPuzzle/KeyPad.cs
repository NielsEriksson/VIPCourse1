using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{

    [SerializeField] int[] correctOrder;
    private List<int> currentOrder;

    [SerializeField] private FirePlace firePlace;

    private void Start()
    {
        currentOrder = new List<int>();
    }

    public void AddIndex(int index)
    {
        currentOrder.Add(index);
        if (currentOrder.Count == correctOrder.Length)
        {
            if (CheckOrder())
            {
                firePlace.OpenFirePlace();
            }
            else
            {
                ResetKeyPad();
            }
            currentOrder = new List<int>();
        }
    }

    private bool CheckOrder()
    {
        for (int i = 0; i < correctOrder.Length; i++)
        {
            if (currentOrder[i] != correctOrder[i])
            {
                return false;
            }
        }
        return true;
    }

    public void ResetKeyPad()
    {
        KeyPadButton[] buttons = GetComponentsInChildren<KeyPadButton>();
        
        foreach (KeyPadButton button in buttons)
        {
            button.ResetButton();
        }
    }
}
