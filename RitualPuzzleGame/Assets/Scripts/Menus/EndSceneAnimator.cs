using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneAnimator : MonoBehaviour
{
    [SerializeField] private GameObject eyes;

    [SerializeField] private GameObject triangle;

    [SerializeField] private int segmentCount;
    [SerializeField] private float radius;

    [SerializeField] private Transform circleParent;

    private List<GameObject> segments;


    private void Start()
    {
        segments = new List<GameObject>();
        DrawCircle();
        StartCoroutine(DrawPoints());
    }

    public void DrawCircle()
    {
        float angle = 360f / segmentCount;
        float radAngle = Mathf.PI / segmentCount;

        float h = Mathf.Abs(radius * Mathf.Cos(radAngle));
        float b = Mathf.Abs(2 * radius * Mathf.Sin(radAngle));

        for (int i = 0; i < segmentCount; i++)
        {
            GameObject segment = Instantiate(triangle, circleParent);

            RectTransform segmentTransform = segment.GetComponent<RectTransform>();
            RectTransform triangleTransform = segment.GetComponentsInChildren<RectTransform>()[1];

            triangleTransform.sizeDelta = new Vector2(b, h);
            triangleTransform.Translate(new Vector3(0, -10 - h));
            segmentTransform.Rotate(0, 0, angle * i);
            segments.Add(segment);
        }
    }

    IEnumerator DrawPoints()
    {
        

        for (int i = 0; i < segmentCount; i++)
        {
            segments[i].SetActive(false);

            yield return new WaitForSeconds(0.1f);
        }

        Destroy(circleParent.gameObject);

        int dex = 6;
        while (dex >= 0)
        {
            dex--;

            eyes.SetActive(!eyes.activeInHierarchy);

            
            yield return new WaitForSeconds((dex % 2) * 1.5f + 0.25f);
        }
    }
}
