using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectInfo : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemSprite;
    public CollectInfo(GameObject prefab, string itemName, Sprite itemSprite)
    {
        this.prefab = prefab;
        this.itemName = itemName;
        this.itemSprite = itemSprite;
    }

    public string GetText()
    {
        return itemName;
    }
    public Sprite GetSprite()
    {
        return itemSprite;
    }
    public GameObject GetPrefab()
    {
        return prefab;
    }
    public void SetNull()
    {
        prefab = null;
        itemName = null;
        itemSprite = null;
    }
}
