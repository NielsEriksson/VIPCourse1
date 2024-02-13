using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FirePlace : MonoBehaviour
{
    [SerializeField] float speed, moveDistance;

    [SerializeField] private Transform endPosition;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            OpenFirePlace();
        }
    }

    public void OpenFirePlace()
    {
        transform.position = endPosition.position;
    }

    //IEnumerator MoveObject(Vector3 end)
    //{
    //    while (transform.position.z < end.z)
    //    {
    //        transform.Translate(speed * Time.deltaTime, 0, 0);
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //    transform.position = end;
    //}
}
