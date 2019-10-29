using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossType1 : MonoBehaviour
{
    [SerializeField] List<Ability> abilities; 

    // Start is called before the first frame update
    void Start()
    {
        abilities = new List<Ability>();
        abilities.Add(GetComponent<ShrinkAndTriplicate>());
        abilities.Add(GetComponent<BossDisappearer>());
        abilities.Add(GetComponent<BossElliptic>());
        abilities[0].StartAbility();
    }

    private void StartAbility()
    {
        abilities[UnityEngine.Random.Range(0,abilities.Count)].StartAbility();
    }

    internal void PhaseOver()
    {
        StartAbility();
    }
}
