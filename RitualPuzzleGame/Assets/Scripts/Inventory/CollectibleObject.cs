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
}
