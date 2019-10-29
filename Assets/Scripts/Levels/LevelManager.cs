using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<Level> levels = new List<Level>();
    [SerializeField] private bool stopSpawning;
    bool allSpawned = false;
    int levelIndex = 0;
    int shipIndex = 0;

    public bool AllSpawned { get => allSpawned; set => allSpawned = value; }


    internal void StartGame()
    {
        allSpawned = false;
        StartCoroutine(LevelSpawner(levels[levelIndex]));
    }

    IEnumerator LevelSpawner(Level level)
    {

        while (!allSpawned && !stopSpawning)
        {
            GetComponent<ShipFactory>().CreateShip(level.GetShip(shipIndex));

            if(++shipIndex > level.GetCount())
            {
                allSpawned = true;
                levelIndex++;
                shipIndex = 0;
                StartCoroutine(GetComponent<GameManager>().LevelOverChecker());
                break;
            }

            yield return new WaitForSeconds(level.GetTime(shipIndex));

        }
    }

    internal void OnLevelOver()
    {
        //block or stop whatever needs to be
        GetComponent<ImprovementsManager>().OnLevelOver();
    }
}
