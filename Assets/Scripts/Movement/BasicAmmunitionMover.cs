using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAmmunitionMover : MonoBehaviour
{
    [SerializeField] private float speed;
    Transform planet;

    private void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, planet.position, speed);
    }
}
