using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Toolbar : MonoBehaviour
{
    [SerializeField] private List<ToolbarSlot> _slots;
    private Dictionary<int, ToolbarSlot> _slotsDict;
    private void Awake()
    {       
        _slotsDict = new Dictionary<int, ToolbarSlot>();
        for (int i = 0; i < _slots.Count; i++)
        {
            _slotsDict[i+1] = _slots[i];
            _slotsDict[i+1].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = (i+1).ToString();
        }
        Debug.Log(_slotsDict.Count);
    }
    private void Start()
    {
        SelectSlot(1);
    }
    private void Update()
    {
        
    }
    private void SelectSlot(int index)
    {
        _slotsDict[index].OnSelected();
    }
    private void CheckAlphaNumericKeys()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {

        }
    }
}
