using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullBossHitManager : MonoBehaviour
{
    PlanetHealthManager planetHealth;
    ImprovementsManager IM;
    BossType4 type4;
    Animator skullAnimator;
    GameObject skull;

    // Start is called before the first frame update
    void Start()
    {
        skull = transform.GetChild(0).gameObject;
        planetHealth = GameObject.FindGameObjectWithTag("PlanetHealth").GetComponent<PlanetHealthManager>();
        IM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ImprovementsManager>();
        skullAnimator = transform.GetChild(0).GetComponent<Animator>();
        type4 = GetComponent<BossType4>();
        StartCoroutine(UpdateSkull());
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (skullActive)
        {
            planetHealth.AddHealth(-IM.GetDamage());
            skullAnimator.Play("Skull Damage");
        }
        else
        {
            GetComponent<HealthBarHolder>().Damage(IM.GetDamage());
        }
    }

    bool skullActive;
    WaitForSeconds skullCycle = new WaitForSeconds(10f);
    IEnumerator UpdateSkull()
    {
        while (true)
        {
            skullActive = !skullActive;
            skull.SetActive(skullActive);
            yield return skullCycle;
        }

    }
}
