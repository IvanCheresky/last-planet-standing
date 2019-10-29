using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFactory : MonoBehaviour
{

    public List<GameObject> ships;
    
    public void CreateRandom() {
        
        GameObject ship = Instantiate(ships[UnityEngine.Random.Range(0, ships.Count)]);
        SetPosition(ship);
    }

    public void CreateShip(GameObject ship)
    {
        GameObject s = Instantiate(ship);
        SetPosition(s);
    }

    private void SetPosition(GameObject ship)
    {
        Vector3 size = ship.GetComponent<SpriteRenderer>().bounds.size;

        if(UnityEngine.Random.value > 0.5f)
        {
            ship.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(-Vector3.zero).x - size.x, UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(Vector3.zero).y, Camera.main.ScreenToWorldPoint(Vector3.up * Screen.height).y - size.y), 0);
        }
        else
        {
            ship.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Vector3.right * Screen.width).x + size.x, UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(Vector3.zero).y, Camera.main.ScreenToWorldPoint(Vector3.up * Screen.height).y - size.y), 0);
        }
    }
}
