using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolbarSlot : MonoBehaviour
{
    private Image _image;
    [SerializeField]private string _text;
    

    private void Awake()
    {
        _image = gameObject.transform.GetChild(0).GetComponent<Image>();    
    }
    public string GetText()
    {
        return _text;
    }
    public void ReturnText()
    {
        string text = DragAndDropController.instance.GetText(_text);
        if (text !="")
        {
            string tempTex = _text;
            _text = text;
        }
        else { _text = ""; }
    }

    public void OnSelected()
    {
        _image.color = Color.green;
    }
    public void OffSelected()
    {
        _image.color = Color.white;
    }
}
