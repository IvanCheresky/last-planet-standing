using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipType6 : MonoBehaviour
{
    bool atDistance;
    public float distance;
    Transform planet;

    // Start is called before the first frame update
    void Start()
    {
        atDistance = false;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScreenEffectManager>().OnDarkShipCreated();
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!atDistance)
        {
            if (Vector2.Distance(transform.position, planet.position) < distance)
            {
                atDistance = true;
            }
        }
        else
        {
            GetComponent<BasicAmmunitionMover>().enabled = false;
            GetComponent<EllipticMover>().enabled = true;
        }

    }
}
