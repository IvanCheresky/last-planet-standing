using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillAbility : MonoBehaviour, Ability
{

    MoveTowardsPlanet moveTowardsPlanet;
    protected PlanetHealthManager phm;
    [SerializeField] private float abilityTime;
    private WaitForSeconds abilityWait;
    // Start is called before the first frame update
    void Awake()
    {
        moveTowardsPlanet = GetComponent<MoveTowardsPlanet>();
        drillWait = new WaitForSeconds(timeBetweenDrillDamage);
        abilityWait = new WaitForSeconds(abilityTime);
        phm = GameObject.FindGameObjectWithTag("PlanetHealth").GetComponent<PlanetHealthManager>();
    }

    [SerializeField] private float distanceToDrill;
    [SerializeField] private float speed;
    public void StartAbility()
    {
        moveTowardsPlanet.ReportWhenNextToPlanet(InPosition, distanceToDrill, speed);
    }

    Coroutine drillCoroutine;
    public void InPosition()
    {
        drillCoroutine = StartCoroutine(Drill());
        StartCoroutine(AbilityDuration());
    }

    [SerializeField] private float timeBetweenDrillDamage;
    [SerializeField] private int damage;
    WaitForSeconds drillWait;

    IEnumerator Drill()
    {
        while (true)
        {
            phm.AddHealth(-damage);
            yield return drillWait;
        }
    }

    IEnumerator AbilityDuration()
    {
        yield return abilityWait;
        StopCoroutine(drillCoroutine);
        GetComponent<BossType3>().PhaseOver();
    }
}
