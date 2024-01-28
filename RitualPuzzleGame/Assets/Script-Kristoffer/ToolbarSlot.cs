using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarSlot : MonoBehaviour
{
    Image image;
    private void Awake()
    {
        image = gameObject.transform.GetChild(0).GetComponent<Image>();
    }
    public void OnSelected()
    {
        image.color = Color.green;
    }
    public void OffSelected()
    {
        image.CrossFadeAlpha(0.0f, 1.0f, true);
    }
}
