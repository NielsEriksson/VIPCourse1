using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DragAndDropController : MonoBehaviour
{
    public static DragAndDropController instance;
    private CollectibleObject _collectedObject;
    [SerializeField] private Image _imageMovable;
    
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
        if(_collectedObject != null)
        {
            _imageMovable.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,-1);
            if(_imageMovable.enabled !=true) _imageMovable.enabled = true; 
        }
        else { if (_imageMovable.enabled == true) _imageMovable.enabled = false; }
    }
    private void SetText()
    {
        _imageMovable.sprite = _collectedObject.GetSprite();
    }
    public CollectibleObject GetItem(CollectibleObject movedItem, InventorySlot inv=null, ToolbarSlot tool=null)
    {
        CollectibleObject tempText = _collectedObject;
        _collectedObject = movedItem;
        if(_collectedObject!=null)
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
        _collectedObject = null;
        SetText();
    }
    private void ReturnText()
    {
        if(_slot)
        {
            //_slot.SetItem(_collectedObject);
            //ClearText();
            //_slot = null;
        }
        else if(_toolSlot)
        {
            _toolSlot.GetItem();
            ClearText();
            _toolSlot = null;
        }
    }
}
