using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : LaserBeam, Ability
{
    public void StartAbility()
    {
        StartCoroutine(DamagePlanet());
        StartCoroutine(AbilityTimeCount());
    }


    [SerializeField] private float abilityTime;
    WaitForSeconds abilityDuration;
    private IEnumerator AbilityTimeCount()
    {
        yield return abilityDuration;
        StopCoroutine(laserDamage);
        GetComponent<BossType3>().PhaseOver();
    }

    // Start is called before the first frame update
    protected override void Awake()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
        phm = GameObject.FindGameObjectWithTag("PlanetHealth").GetComponent<PlanetHealthManager>();
        abilityDuration = new WaitForSeconds(abilityTime);
    }
}
