using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipType6Destroyer : MonoBehaviour, Destroyer
{
    public void OnDestroyShip()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScreenEffectManager>().OnDarkShipDestroyed();
        Destroy(gameObject);
    }
}
