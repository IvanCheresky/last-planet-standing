using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipType1 : MonoBehaviour
{
    Transform planet;

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
        GetComponent<MoveTowardsPlanet>().ReportWhenNextToPlanet(AtDistance);
    }

    public void AtDistance()
    {
        GetComponent<MoveTowardsPlanet>().enabled = false;
        GetComponent<EllipticMover>().enabled = true;
    }
}
