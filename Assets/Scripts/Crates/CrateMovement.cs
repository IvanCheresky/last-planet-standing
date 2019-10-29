using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateMovement : MonoBehaviour
{
    Vector3 axis;
    bool left;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        axis = transform.position + Vector3.right * 2.5f;

        if(Random.value < 0)
        {
            left = true;
            axis = transform.position + Vector3.left * 2.5f;
        }
    }

    void FixedUpdate()
    {
        if (left)
        {
            transform.RotateAround(axis, Vector3.back, speed);
        }
        else
        {
            transform.RotateAround(axis, Vector3.forward, speed);
        }

        if (left && transform.position.x <  axis.x)
        {
            axis = transform.position + Vector3.right * 2.5f;
            left = false;
        }
        else if(!left && transform.position.x > axis.x)
        {
            axis = transform.position + Vector3.left * 2.5f;
            left = true;
        }

        transform.rotation = Quaternion.identity;
    }
}
