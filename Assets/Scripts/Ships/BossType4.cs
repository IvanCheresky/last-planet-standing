using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossType4 : MonoBehaviour
{
    [SerializeField] List<Ability> abilities; 

    // Start is called before the first frame update
    void Start()
    {
        abilities = new List<Ability>();
        foreach(BossShooter component in GetComponents<BossShooter>())
        {
            abilities.Add(component);
        }
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
