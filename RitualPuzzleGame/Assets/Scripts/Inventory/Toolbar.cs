using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Toolbar : MonoBehaviour
{
    [Header("Lists")]
    [SerializeField] private List<ToolbarSlot> _slots;
    private Dictionary<int, ToolbarSlot> _slotsDict;
    private ToolbarSlot _selectedKey;
    private int _currentSlot;
    [Header("TextSlot")]
    [SerializeField] private TextMeshProUGUI _centerText;
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
        CheckAlphaNumericKeys();
        OnScroll();
    }
    private void SelectSlot(int index)
    {
        _currentSlot = index;
        if(_selectedKey!=null){ _selectedKey.OffSelected(); }
        _slotsDict[index].OnSelected();
        _selectedKey = _slotsDict[index];
        UpdateItem();
    }
    private void OnScroll()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(_currentSlot==_slotsDict.Count){_currentSlot = 1;}
            else{ _currentSlot++; }
            SelectSlot(_currentSlot);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (_currentSlot == 1) { _currentSlot = _slotsDict.Count; }
            else { _currentSlot--; }
            SelectSlot(_currentSlot);
        }
    }
    private void CheckAlphaNumericKeys()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectSlot(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectSlot(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectSlot(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SelectSlot(8);
        }
    }
    private void UpdateItem()
    {
        _centerText.text = _slotsDict[_currentSlot].GetText();
    }
}
