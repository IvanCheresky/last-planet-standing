using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipType5Destroyer : MonoBehaviour, Destroyer
{
    [SerializeField] private GameObject shipToSpawn;
    [SerializeField] private float offset;

    public void OnDestroyShip()
    {
        Instantiate(shipToSpawn, transform.position + Vector3.right * offset, Quaternion.identity);
        Instantiate(shipToSpawn, transform.position + Vector3.up * offset, Quaternion.identity);
        Instantiate(shipToSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
