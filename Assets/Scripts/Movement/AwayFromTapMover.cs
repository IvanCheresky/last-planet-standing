using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwayFromTapMover : MonoBehaviour
{
    Vector3 touchPosition;
    [SerializeField] float speed;

    private void Awake()
    {
        /*
        if(transform.position.x < 0)
        {
            touchPosition.x = -10;
        }else{
            touchPosition.x = 10;
        }
        */
    }

    Vector3 normalizedPos;
    Vector3 newPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<BasicAmmunitionMover>().enabled)
        {
            return;
        }

        normalizedPos = (touchPosition - transform.position).normalized;
        normalizedPos.z = 0;

        newPosition = transform.position + normalizedPos * -speed;

        newPosition.x = Mathf.Clamp(newPosition.x, -7f, 7f);
        newPosition.y = Mathf.Clamp(newPosition.y, -3.5f, 3.5f);

        transform.position = newPosition;

    }
}
