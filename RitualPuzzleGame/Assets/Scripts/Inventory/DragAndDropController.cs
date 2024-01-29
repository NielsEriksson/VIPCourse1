using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DragAndDropController : MonoBehaviour
{
    public static DragAndDropController instance;
    private string _textDrop = "";
    [SerializeField] private GameObject _textMovable;
    private InventorySlot _slot;
    private ToolbarSlot _toolSlot;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }             
    }
    private void Update()
    {
        if(_textDrop != "")
        {
            _textMovable.transform.position = Input.mousePosition;
        }
    }
    private void SetText()
    {
        _textMovable.GetComponent<TextMeshProUGUI>().text = _textDrop;
    }
    public string GetText(string movedText, InventorySlot inv=null, ToolbarSlot tool=null)
    {
        string tempText = _textDrop;
        _textDrop = movedText;
        SetText();
        SetOrigin(inv, tool);
        return tempText;
    }

    private void SetOrigin(InventorySlot inv, ToolbarSlot tool)
    {
        if(inv)
        {
            _slot = inv;
        }
        else if(tool)
        {
            _toolSlot = tool;
        }
    }
    private void ClearText()
    {
        _textDrop = "";
        SetText();
    }
    private void ReturnText()
    {
        if(_slot)
        {
            _slot.SetItem(_textDrop);
            ClearText();
            _slot = null;
        }
        else if(_toolSlot)
        {
            _toolSlot.GetText();
            ClearText();
            _toolSlot = null;
        }
    }
}
