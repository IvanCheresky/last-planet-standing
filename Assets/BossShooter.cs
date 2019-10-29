using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooter : BasicShooter, Ability
{
    private void Start()
    {
        active = false;
        shootingTime = new WaitForSeconds(time);
    }
    public void StartAbility()
    {
        active = true;
        StartCoroutine(CountDown());
    }


    [SerializeField] float time;
    WaitForSeconds shootingTime;

    IEnumerator CountDown()
    {
        yield return shootingTime;
        GetComponent<BossType4>().PhaseOver();
    }

}
