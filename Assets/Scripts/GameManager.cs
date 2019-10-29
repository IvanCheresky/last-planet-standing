using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool checking;
    public float timeBetweenGameOverChecks;

    private void Start()
    {
        checking = false;
        GetComponent<LevelManager>().StartGame();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator LevelOverChecker()
    {
        checking = true;

        while (checking)
        {
            if(GameObject.FindGameObjectWithTag("Ship") == null && GameObject.FindGameObjectWithTag("Ammunition") == null)
            {
                checking = false;
                GetComponent<LevelManager>().OnLevelOver();
                break;
            }

            yield return new WaitForSeconds(timeBetweenGameOverChecks);
        }
    }
}
