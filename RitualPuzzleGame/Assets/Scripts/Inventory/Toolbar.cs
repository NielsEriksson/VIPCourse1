using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

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
    
    private void SelectSlot(int index)
    {
        _currentSlot = index;
        if(_selectedKey!=null){ _selectedKey.OffSelected(); }
        _slotsDict[index].OnSelected();
        _selectedKey = _slotsDict[index];
        UpdateItem();
    }
    private void OnScrollToolBar(InputValue value)
    {
        if (value.Get<float>()>  0f)
        {
            if (_currentSlot == _slotsDict.Count) { _currentSlot = 1; }
            else { _currentSlot++; }
            SelectSlot(_currentSlot);
        }
        if (value.Get<float>() < 0f)
        {
            if (_currentSlot == 1) { _currentSlot = _slotsDict.Count; }
            else { _currentSlot--; }
            SelectSlot(_currentSlot);
        }
    }
 
    private void OnSelectToolBar(InputValue value)
    {
        SelectSlot(int.Parse(Input.inputString));
    }
   
    private void UpdateItem()
    {
        if(_slotsDict[_currentSlot].GetText()!="")
            _centerText.text = _slotsDict[_currentSlot].GetText();
        else _centerText.text = ""; 
    }
    public int CheckAvailible()
    {
        for (int i = 1; i < _slotsDict.Count; i++)
            if (_slotsDict[i].GetItem().GetSprite() == null)
                return i;
        return 0;
    }
    public void SetItem(int i, CollectibleObject co)
    {
        _slotsDict[i].SetItem(co);
    }
}
