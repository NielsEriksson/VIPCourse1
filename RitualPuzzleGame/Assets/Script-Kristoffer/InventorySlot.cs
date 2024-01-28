using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private string text=""; 
    public string SetItem(string textadd)
    {
        string tempText = text;
        text = textadd;
        return tempText;
    }
    public string GetItem(string str)
    {
        string tempText = text;
        if(str==null){ClearText();}
        else { SetItem(str);}
        return tempText;

    }
    private void ClearText()
    {
        text = "";
    }
}
