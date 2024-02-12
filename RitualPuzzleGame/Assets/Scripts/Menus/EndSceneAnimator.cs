using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneAnimator : MonoBehaviour
{
    [SerializeField] private GameObject go;

    private void Start()
    {
        StartCoroutine(DrawPoints());
    }

    IEnumerator DrawPoints()
    {
        int i = 5;
        while (i >= 0)
        {
            i--;

            go.SetActive(!go.activeInHierarchy);

            
            yield return new WaitForSeconds(2);
        }
    }
}
