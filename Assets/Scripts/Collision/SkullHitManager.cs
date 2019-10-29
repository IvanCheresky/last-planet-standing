using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullHitManager : MonoBehaviour
{
    PlanetHealthManager planetHealth;
    ImprovementsManager IM;
    ShipType10 type10;
    Animator skullAnimator;

    // Start is called before the first frame update
    void Start()
    {
        planetHealth = GameObject.FindGameObjectWithTag("PlanetHealth").GetComponent<PlanetHealthManager>();
        IM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ImprovementsManager>();
        skullAnimator = transform.GetChild(0).GetComponent<Animator>();
        type10 = GetComponent<ShipType10>();
    }

    [SerializeField] private GameObject goodHitEffect;
    [SerializeField] private float goodHitDuration;

    // Update is called once per frame
    private void OnMouseDown()
    {
        Debug.Log(type10.Skull());
        if (type10.Skull())
        {
            planetHealth.AddHealth(-IM.GetDamage());
            skullAnimator.Play("Skull Damage");
        }else{
            Destroy(Instantiate(goodHitEffect, transform.position, Quaternion.identity), goodHitDuration);
            GetComponent<HealthBarHolder>().Damage(IM.GetDamage());
        }
    }
}
