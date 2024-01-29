using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "CollectibleObject")]
public class CollectibleObject : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemSprite;
    public CollectibleObject(GameObject prefab, string itemName, Sprite itemSprite)
    {
        this.prefab = prefab;
        this.itemName = itemName;
        this.itemSprite = itemSprite;
    }

    public CollectibleObject GetItem()
    {
        return this;
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
    public void SetCollectible(CollectInfo cI)
    {
        this.prefab = cI.GetPrefab();
        this.itemName = cI.GetText();
        this.itemSprite = cI.GetSprite();
    }
}
