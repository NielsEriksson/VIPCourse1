using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetKeyPad();
        }
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
