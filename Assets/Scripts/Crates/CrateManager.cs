using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateManager : MonoBehaviour
{
    public GameObject crate;
    float timePassed;
    float timeTotal;
    public float minTimeBetweenCrates;
    public float maxTimeBetweenCrates;

    // Start is called before the first frame update
    void Start()
    {
        SetTotalTime();
    }


    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<LevelManager>().AllSpawned)
        {
            timePassed += Time.deltaTime;

            if(timePassed > timeTotal)
            {
                CreateCrate();
                timePassed = 0;
                SetTotalTime();
            }
        }
        else
        {
            timePassed = 0;
        }
    }

    private void SetTotalTime()
    {
        timeTotal = UnityEngine.Random.Range(minTimeBetweenCrates / GetComponent<ImprovementsManager>().HealthCratesMultiplier, maxTimeBetweenCrates / GetComponent<ImprovementsManager>().HealthCratesMultiplier);
    }

    private void CreateCrate()
    {
        Instantiate(crate, new Vector3(UnityEngine.Random.Range(-8f,8f), 6f, 0), Quaternion.identity);
    }
}
