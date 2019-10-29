using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDisappearer : Disappearer, Ability
{
    Coroutine moveToNewSpot;

    new void Start(){
        nextCycleTime = new WaitForSeconds(3f);
    }

    public void StartAbility()
    {
        Debug.Log("starting disappearer");
        moveToNewSpot = StartCoroutine(MoveToNewSpot());
        StartCoroutine(WaitAndChangeAbility());
    }

    WaitForSeconds abilityTime = new WaitForSeconds(15f);

    IEnumerator WaitAndChangeAbility()
    {
        yield return abilityTime;
        StopCoroutine(moveToNewSpot);
        GetComponent<BossType1>().PhaseOver();
    }
}
