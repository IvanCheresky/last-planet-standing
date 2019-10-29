using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappearer : MonoBehaviour
{
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    WaitForSeconds reappearTime = new WaitForSeconds(1f);
    protected WaitForSeconds nextCycleTime = new WaitForSeconds(6f);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveToNewSpot());
    }

    protected IEnumerator MoveToNewSpot()
    {
        while (true)
        {
            GetComponent<Animator>().Play("Disappear");
            if (GetComponent<BasicShooter>())
            {
            GetComponent<BasicShooter>().enabled = false;
            }
            if (GetComponent<HealthBarHolder>())
            {
            GetComponent<HealthBarHolder>().Hide();
            }
            yield return reappearTime;
            GetComponent<Animator>().Play("Reappear");
            transform.position = new Vector3(UnityEngine.Random.Range(minX, maxX) * RandomSign(), UnityEngine.Random.Range(minY, maxY) * RandomSign(), 0);
            if (GetComponent<BasicShooter>())
            {
                GetComponent<BasicShooter>().enabled = true;
            }
            yield return reappearTime;
            if (GetComponent<HealthBarHolder>())
            {
                GetComponent<HealthBarHolder>().Show();
            }
            yield return nextCycleTime;
        }
    }

    int RandomSign() {
        return UnityEngine.Random.value< .5? 1 : -1;
    }
}
