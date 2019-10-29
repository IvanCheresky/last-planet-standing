using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDestroy : MonoBehaviour, Destroyer
{

    [SerializeField] private GameObject deathEffect;
    [SerializeField] private float deathEffectDuration;
    public void OnDestroyShip()
    {
        if (deathEffect)
        {
            Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity), deathEffectDuration);
        }
        Destroy(gameObject);
    }
}
