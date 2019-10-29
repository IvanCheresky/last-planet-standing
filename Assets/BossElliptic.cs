using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossElliptic : EllipticMover, Ability
{
    public void StartAbility()
    {
        Debug.Log("starting elliptic");
        active = true;
        StartCoroutine(EllipticAbility());
    }

    WaitForSeconds abilityTime = new WaitForSeconds(10f);

    IEnumerator EllipticAbility()
    {
        yield return abilityTime;
        active = false;
        GetComponent<BossType1>().PhaseOver();
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    bool active = false;
    // Update is called once per frame
    override protected void FixedUpdate()
    {
        if (active)
        {
            base.FixedUpdate();
        }
    }
}
