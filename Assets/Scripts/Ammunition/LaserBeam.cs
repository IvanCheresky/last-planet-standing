using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    protected LineRenderer lineRenderer;
    protected Transform planet;
    protected PlanetHealthManager phm;
    public int damage;
    protected Coroutine laserDamage;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
        phm = GameObject.FindGameObjectWithTag("PlanetHealth").GetComponent<PlanetHealthManager>();
    }

    private Coroutine damagePlanet;

    private void OnEnable()
    {
        damagePlanet = StartCoroutine(DamagePlanet());
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, planet.position);
    }

    private void OnDisable()
    {
        if (damagePlanet != null)
        {
            StopCoroutine(damagePlanet);
        }
    }

    protected IEnumerator DamagePlanet()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            phm.AddHealth(-damage);
        }
    }
}
