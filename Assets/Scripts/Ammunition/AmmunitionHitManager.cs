using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionHitManager : MonoBehaviour
{
    public int totalTaps;
    int currentTaps;

    private void OnMouseDown()
    {
        currentTaps++;

        if(currentTaps >= totalTaps)
        {
            Destroy(gameObject);
        }
    }
}
