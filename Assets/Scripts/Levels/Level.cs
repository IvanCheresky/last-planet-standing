using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Level")]
public class Level: ScriptableObject
{
    [SerializeField] List<NewEnemy> ships = new List<NewEnemy>();

    public float GetTime(int index)
    {
        return ships[0].GetTime();
    }


    public GameObject GetShip(int index)
    {
        return ships[0].GetShip();
    }

    public int GetCount()
    {
        return ships.Count - 1;
    }
}
