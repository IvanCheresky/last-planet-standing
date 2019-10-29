using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossType3 : MonoBehaviour
{
    [SerializeField] List<Ability> abilities; 

    // Start is called before the first frame update
    void Start()
    {
        abilities = new List<Ability>();
        abilities.Add(GetComponent<DrillAbility>());
        abilities.Add(GetComponent<BossLaser>());
        abilities.Add(GetComponent<Ship3Spawner>());
        abilities[0].StartAbility();
    }

    private void StartAbility()
    {
        abilities[UnityEngine.Random.Range(0,abilities.Count)].StartAbility();
    }

    internal void PhaseOver()
    {
        Debug.Log("phase over");
        StartAbility();
    }
}
