using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitterMover : MonoBehaviour
{
    public float speed;
    Transform planet;

    private void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
    }

    float counter;
    // Update is called once per frame
    void FixedUpdate()
    {
        counter += Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector3(Mathf.PingPong(counter, 18) - 9, Mathf.PingPong(counter, 10) - 5, transform.position.z), speed);
    }
}
