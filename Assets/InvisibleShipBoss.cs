using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleShipBoss : InvisibleShipMover, Ability
{
    public void StartAbility()
    {
        active = true;
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    private bool active = false;
    [SerializeField] private int repetitions;
    private int currentRepetitions = 0;
    // Update is called once per frame
    new void FixedUpdate()
    {
        if (active)
        {
            if (Vector3.Distance(transform.position, point) < Mathf.Epsilon && !pointReached)
            {
                if(++currentRepetitions >= repetitions)
                {
                    active = false;
                    GetComponent<BossType2>().PhaseOver();
                    return;
                }
            }
            base.FixedUpdate();
        }
    }
}
