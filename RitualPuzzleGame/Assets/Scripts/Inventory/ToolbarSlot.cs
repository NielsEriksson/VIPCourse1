using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class ToolbarSlot : MonoBehaviour
{
    private Image _bgImage;
    private Image _image;
    
    private CollectInfo _info;

    private void Awake()
    {
        _bgImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        _image = gameObject.transform.GetChild(1).GetComponent<Image>();
        
    }
    private void Start()
    {
        if(_info==null)
        {
            _info = new CollectInfo(null, "", null);
        }
        SetImage();
    }
    public string GetText()
    {
        if(_info != null)
            return _info.GetText();
        return "";
    }
    public CollectInfo GetItem()
    {
        return _info;
    }
    public void SetItem(CollectibleObject co)
    {       
        _info = new CollectInfo(co.GetPrefab(), co.GetText(), co.GetSprite());       
        SetImage();
        
    }
    public void ReturnItem()
    {
        CollectInfo item = DragAndDropController.instance.GetItem(_info);
        if (item != null)
        {
            CollectInfo tempTex = _info;
            _info = item;           
        }
        else { _info.SetNull(); }
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
        if(_info.GetSprite()!=null)
        {
            _image.CrossFadeAlpha(1f, 0.5f, true);
            _image.sprite = _info.GetSprite();
        }
        else { _image.CrossFadeAlpha(0f,0.5f,true); }
    }
}
