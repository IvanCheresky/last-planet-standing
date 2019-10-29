using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    ImprovementsManager IM;

    private void Start()
    {
        IM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ImprovementsManager>();
    }

    [SerializeField] private GameObject hitEffect;
    [SerializeField] private float hitEffectDuration;

    protected virtual void OnMouseDown()
    {
        if (hitEffect)
        {
            Destroy(Instantiate(hitEffect, transform.position, Quaternion.identity), hitEffectDuration);
        }
        GetComponent<HealthHolder>().Damage(IM.GetDamage());
    }
}
