using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipType8 : MonoBehaviour
{
    // Update is called once per frame
    bool away;

    void Update()
    {
        if (!away && (transform.position.x > -7f && transform.position.x < 7f) && (transform.position.y > -3.5f && transform.position.y < 3.5f))
        {
            GetComponent<BasicAmmunitionMover>().enabled = false;
            away = true;
        }
    }
}
