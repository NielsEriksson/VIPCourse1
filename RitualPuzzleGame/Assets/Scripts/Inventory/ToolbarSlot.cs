using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System;

public class ToolbarSlot : MonoBehaviour
{
    private Image _bgImage;
    private Image _image;
    private GameObject tempVis;
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
        if (_bgImage.color == Color.green) SetCarry();

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
    private void SetCarry()
    {
        
        GameObject play = GameObject.FindGameObjectWithTag("Player");
        GameObject prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/" + _info.GetPrefab() + ".prefab", typeof(GameObject)) as GameObject;
        if(tempVis!=null)
        {
            Debug.Log(tempVis.name + " : " + prefab.name);
            if (tempVis.name != prefab.name + "(Clone)")
            {
                tempVis = Instantiate(prefab, play.transform.position, Quaternion.identity);
                PlayerPickUp.instance.PickUp(tempVis, this);
            }
        }
        else
        {
            tempVis = Instantiate(prefab, play.transform.position, Quaternion.identity);
            PlayerPickUp.instance.PickUp(tempVis, this);
        }
        
    }
    public void OnSelected()
    {       

            _bgImage.color = Color.green;
            if (_info.GetSprite() != null)
            {
                SetCarry();
            }
            else
            {
                PlayerPickUp.instance.DestroyCarriedItem();
            }            
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

    internal void DropItem()
    {
        if (_info.GetSprite() != null)
        {
            PlayerPickUp.instance.DestroyCarriedItem();
            Debug.Log(_info.GetPrefab());
            GameObject prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/"+ _info.GetPrefab()+".prefab", typeof(GameObject)) as GameObject;
            
            Instantiate(prefab, PlayerPickUp.instance.holdingPos.position, Quaternion.identity);

            ClearItem();
        }
    }
    public void ClearItem()
    {
        _info.SetNull();
        SetImage();
    }
}
