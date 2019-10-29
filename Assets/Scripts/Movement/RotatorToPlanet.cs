using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorToPlanet : MonoBehaviour
{
    Transform planet;

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
    }

    // Update is called once per frame
    private Vector3 direction;

    void FixedUpdate()
    {
        direction = planet.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
