using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionSpawnEffect : MonoBehaviour
{
    [SerializeField] private GameObject spawnEffect;
    [SerializeField] private float spawnEffectDuration;
    // Start is called before the first frame update
    void Start()
    {
        if (spawnEffect)
        {
            Destroy(Instantiate(spawnEffect, transform.position, Quaternion.identity), spawnEffectDuration);
        }
    }

}
