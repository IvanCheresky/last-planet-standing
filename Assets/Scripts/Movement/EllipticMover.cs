using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipticMover : MonoBehaviour
{
    Transform planet;
    [SerializeField] float speed;

    protected void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").transform;    
    }

    virtual protected void FixedUpdate()
    {
        transform.RotateAround(planet.position, Vector3.back, speed);
    }
}
