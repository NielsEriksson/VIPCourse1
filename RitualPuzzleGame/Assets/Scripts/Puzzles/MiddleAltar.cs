using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiddleAltar : MonoBehaviour,IInteractable
{
    private int litCandles = 0;
    public List<GameObject> UnlitCandles;
    public void Interact()
    {
        GameObject carryingObject = PlayerPickUp.instance.GetCurrentItem();
        if (carryingObject.transform.tag != "PuzzleBook") return;

        LightCandle(GetCandleToLight(), carryingObject);
        CheckVictory();
    }

    public void SetInteractionMessage(GameObject eInteract)
    {
        if (PlayerPickUp.instance != null && (PlayerPickUp.instance.GetCurrentItem()==null|| PlayerPickUp.instance.GetCurrentItem().tag!="PuzzleBook"))
        {
            eInteract.GetComponent<CanvasGroup>().alpha = 0;
            GetComponent<Outline>().enabled = false;
            return;
        }
        eInteract.GetComponentInChildren<TMP_Text>().text = "Place Book";
    }
    public int GetCandleToLight()
    {
        int candleToLight = Random.Range(0, UnlitCandles.Count - 1);
        return candleToLight;
    }
    public void LightCandle(int candle, GameObject book) 
    {
        UnlitCandles[candle].transform.GetChild(0).gameObject.SetActive(true);
        litCandles++;
        PlayerPickUp.instance.ReleaseItem();
        book.transform.position = UnlitCandles[candle].transform.GetChild(1).transform.position;
        book.transform.eulerAngles = Vector3.zero;
        UnlitCandles.RemoveAt(candle);
    }
    public void CheckVictory()
    {
        if(litCandles !=5) { return; }
        //win stuff thing sin here
    }
}
