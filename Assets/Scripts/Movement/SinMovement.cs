using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMovement : MonoBehaviour
{
    public float speed;
    Transform planet;
    Vector2 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        newPosition = Vector2.MoveTowards(transform.position, planet.position + new Vector3(Mathf.Sin(Time.time) * 5, Mathf.Cos(Time.time) * 5), speed);
        transform.position = newPosition;
        
    }
}
