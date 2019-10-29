using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooter : MonoBehaviour
{

    [SerializeField] GameObject ammunition;
    [SerializeField] float delay;
    [SerializeField] float delayRandomMax;
    float delayRandom;
    float timeSinceLastShot;
    protected bool active;
    [SerializeField] int damage;

    private void Start()
    {
        delayRandom = Random.Range(-delayRandomMax, delayRandomMax);
    }

    // Update is called once per frame
    void Update()
    {
        active = true; //to change

        if (active)
        {
            timeSinceLastShot += Time.deltaTime;

            if(timeSinceLastShot > delay + delayRandom)
            {
                GameObject amm = Instantiate(ammunition);

                amm.transform.position = transform.position;

                amm.GetComponent<AmmunitionCollision>().SetDamage(damage);

                timeSinceLastShot -= delay;

                delayRandom = Random.Range(-delayRandomMax, delayRandomMax);
            }
        }
    }
}
