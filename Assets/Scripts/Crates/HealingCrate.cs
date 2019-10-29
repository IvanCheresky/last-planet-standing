using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingCrate : MonoBehaviour
{
    PlanetHealthManager planetHealth;
    ImprovementsManager im;
    public int heal;

    private void Start()
    {
        planetHealth = GameObject.FindGameObjectWithTag("PlanetHealth").GetComponent<PlanetHealthManager>();
        im = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ImprovementsManager>();
    }

    [SerializeField] private GameObject particleEffect;

    private void OnMouseDown()
    {
        Destroy(Instantiate(particleEffect, transform.position, Quaternion.identity), 5f);
        planetHealth.AddHealth((int)(heal * im.HealthFromCratesMultiplier));
        Destroy(gameObject);
    }
}
