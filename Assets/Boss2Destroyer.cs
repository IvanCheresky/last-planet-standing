using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Destroyer : MonoBehaviour, Destroyer
{
    [SerializeField] private GameObject shipToSpawn1;
    [SerializeField] private GameObject shipToSpawn2;
    [SerializeField] private GameObject shipToSpawn3;
    [SerializeField] private GameObject shipToSpawn4;
    [SerializeField] private GameObject shipToSpawn5;

    [SerializeField] private Vector2 coords1;
    [SerializeField] private Vector2 coords2;
    [SerializeField] private Vector2 coords3;
    [SerializeField] private Vector2 coords4;
    [SerializeField] private Vector2 coords5;

    public void OnDestroyShip()
    {
        //add some effect?
        Instantiate(shipToSpawn1, coords1, Quaternion.identity);
        Instantiate(shipToSpawn2, coords2, Quaternion.identity);
        Instantiate(shipToSpawn3, coords3, Quaternion.identity);
        Instantiate(shipToSpawn4, coords4, Quaternion.identity);
        Instantiate(shipToSpawn5, coords5, Quaternion.identity);
        Destroy(gameObject);
    }
}
