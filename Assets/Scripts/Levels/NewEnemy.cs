using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class NewEnemy : ScriptableObject
{
    [SerializeField] List<GameObject> ships;
    [SerializeField] float time;
    [SerializeField] float timeRandomness;

    internal float GetTime()
    {
        return time + UnityEngine.Random.Range(-timeRandomness, timeRandomness);
    }

    internal GameObject GetShip()
    {
        return ships[UnityEngine.Random.Range(0, ships.Count)];
    }
}
