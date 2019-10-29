
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAmmunitionCollision : MonoBehaviour, AmmunitionCollision
{
    int damage;
    PlanetHealthManager planetHealth;

    private void Start()
    {
        planetHealth = GameObject.FindGameObjectWithTag("PlanetHealth").GetComponent<PlanetHealthManager>();
    }

    [SerializeField] private GameObject hitEffect;
    [SerializeField] private float hitEffectDuration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planet")
        {
            planetHealth.AddHealth(-damage);
            if (hitEffect)
            {
                Destroy(Instantiate(hitEffect, transform.position, Quaternion.identity), hitEffectDuration);
            }
            Destroy(gameObject);
        }
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }


}
