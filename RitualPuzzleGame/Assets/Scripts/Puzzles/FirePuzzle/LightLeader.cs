using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLeader : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector3 direction;

    private void Start()
    {
        direction = transform.parent.transform.forward;
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            FireNode fireNode = other.GetComponent<FireNode>();
            if (fireNode != null)
            {
                Vector3 rotation = fireNode.transform.localEulerAngles;
                if (transform.forward == Vector3.forward)
                {
                    if (rotation.y == 315f)
                    {
                        transform.Rotate(new Vector3(0, 90, 0), Space.Self);
                    }
                    else if (rotation.y == 225f)
                    {
                        transform.forward = Vector3.left;
                    }
                }
                else if (transform.forward == Vector3.back)
                {

                }
                else if (transform.forward == Vector3.left)
                {

                }
                else if (transform.forward == Vector3.right)
                {

                }
            }
        }
    }
}
