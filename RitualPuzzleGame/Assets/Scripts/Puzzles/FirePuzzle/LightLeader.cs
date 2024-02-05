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
                int turn = (int)Mathf.Round(rotation.y);

                transform.position = fireNode.transform.position;

                if (transform.forward == Vector3.forward)
                {
                    if (turn == 135)
                    {
                        transform.Rotate(new Vector3(0, 90, 0), Space.Self);
                        return;
                    }
                    else if (turn == 225)
                    {
                        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                        return;
                    }
                }
                else if (transform.forward == Vector3.back)
                {
                    if (turn == 315)
                    {
                        transform.Rotate(new Vector3(0, 90, 0), Space.Self);
                        return;
                    }
                    else if (turn == 45)
                    {
                        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                        return;
                    }
                }
                else if (transform.forward == Vector3.left)
                {
                    if (turn == 45)
                    {
                        transform.Rotate(new Vector3(0, 90, 0), Space.Self);
                        return;
                    }
                    else if (turn == 315)
                    {
                        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                        return;
                    }
                }
                else if (transform.forward == Vector3.right)
                {
                    if (turn == 225)
                    {
                        transform.Rotate(new Vector3(0, 90, 0), Space.Self);
                        return;
                    }
                    else if (turn == 135)
                    {
                        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                        return;
                    }
                }
            }
        }
        Destroy(gameObject);
    }
}
