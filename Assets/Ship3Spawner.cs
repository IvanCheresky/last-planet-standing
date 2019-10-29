using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship3Spawner : MonoBehaviour, Ability
{
    MoveTowardsPlanet moveTowardsPlanet;

    void Awake()
    {
        moveTowardsPlanet = GetComponent<MoveTowardsPlanet>();
        waitTime = new WaitForSeconds(timeToWait);
    }

    [SerializeField] private float maxDistanceToSpawn;
    [SerializeField] private float minDistanceToSpawn;
    [SerializeField] private float speed;

    public void StartAbility()
    {
        moveTowardsPlanet.ReportWhenNextToPlanet(InPosition, maxDistanceToSpawn, minDistanceToSpawn, speed);
    }

    [SerializeField] private GameObject shipType3;
    [SerializeField] private List<Vector2> coords;
    [SerializeField] private float timeToWait;
    private WaitForSeconds waitTime;
    private List<GameObject> ships = new List<GameObject>();

    void InPosition()
    {
        //ANIMATION
        foreach(Vector2 coord in coords)
        {
            ships.Add(Instantiate(shipType3, coord, Quaternion.identity));
        }

        StartCoroutine(WaitAndReturn());
    }

    IEnumerator WaitAndReturn()
    {
        while (spawanedShipsStillAlive())
        {
            yield return waitTime;
        }
        Debug.Log("calling phase over");
        GetComponent<BossType3>().PhaseOver();
    }

    private bool spawanedShipsStillAlive()
    {
        for(int i = 0; i < ships.Count; i++)
        {
            if(ships[i] == null)
            {
                ships.Remove(ships[i]);
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}
