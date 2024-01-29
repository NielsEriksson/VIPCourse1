using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolbarSlot : MonoBehaviour
{
    private Image _bgImage;
    private Image _image;
    [SerializeField] private CollectibleObject _object;
    

    private void Awake()
    {
        if(_object == null)
        {
            _object = new CollectibleObject();
        }
        _bgImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        _image = gameObject.transform.GetChild(1).GetComponent<Image>();
        SetImage();
    }
    public string GetText()
    {
        if(_object != null)
            return _object.GetText();
        return "";
    }
    public CollectibleObject GetItem()
    {
        return _object;
    }
    public void SetItem(CollectibleObject co)
    {
        _object = co;
        SetImage();
    }
    public void ReturnItem()
    {
        CollectibleObject item = DragAndDropController.instance.GetItem(_object);
        if (item != null)
        {
            CollectibleObject tempTex = _object;
            _object = item;           
        }
        else { _object = null; }
        SetImage();
    }

    public void OnSelected()
    {
        _bgImage.color = Color.green;
    }
    public void OffSelected()
    {
        _bgImage.color = Color.white;
    }
    private void SetImage()
    {
        if(_object!=null)
        {
            _image.CrossFadeAlpha(1f, 0.5f, true);
            _image.sprite = _object.GetSprite();
        }
        else { _image.CrossFadeAlpha(0f,0.5f,true); }
    }
}
