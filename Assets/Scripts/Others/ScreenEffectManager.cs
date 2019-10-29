using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffectManager : MonoBehaviour
{
    public GameObject darkSprite;
    int darkShipCount;
    
    public void OnDarkShipCreated()
    {
        if(darkShipCount == 0)
        {
            //darkSprite.GetComponent<Animator>().enabled = true;
            darkSprite.GetComponent<Animator>().Play("Darken");
        }

        darkShipCount++;
    }

    public void OnDarkShipDestroyed()
    {
        darkShipCount--;

        if(darkShipCount <= 0)
        {
            darkSprite.GetComponent<Animator>().Play("Illuminate");
        }
    }
}
