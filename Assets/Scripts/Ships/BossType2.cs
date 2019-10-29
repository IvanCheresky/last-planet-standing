using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossType2 : MonoBehaviour
{
    [SerializeField] List<Ability> abilities; 

    // Start is called before the first frame update
    void Start()
    {
        abilities = new List<Ability>();
        abilities.Add(GetComponent<MeteorAbility>());
        abilities.Add(GetComponent<InvisibleShipBoss>());
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

    internal void OnPointReached()
    {
        StartCoroutine(WaitAndMove());

    }

    IEnumerator WaitAndMove()
    {
        //bs.enabled = true; //SHOOT
        yield return new WaitForSeconds(10f);
        GetComponent<Animator>().Play("Turn Invisible");
        //bs.enabled = false; //STOP SHOOTING
        GetComponent<InvisibleShipMover>().SetPoint();
    }
}
