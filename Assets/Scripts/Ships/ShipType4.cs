using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipType4 : MonoBehaviour
{
    BasicShooter bs;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<HealthBarHolder>().Hide();
        bs = GetComponent<BasicShooter>();
    }

    internal void OnPointReached()
    {
        StartCoroutine(WaitAndMove());
    }

    IEnumerator WaitAndMove()
    {
        bs.enabled = true;
        yield return new WaitForSeconds(10f);
        GetComponent<Animator>().Play("Turn Invisible");
        GetComponent<HealthBarHolder>().Hide();
        bs.enabled = false;
        GetComponent<InvisibleShipMover>().SetPoint();
    }
}
