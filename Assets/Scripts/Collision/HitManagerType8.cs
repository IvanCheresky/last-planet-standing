using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManagerType8 : HitManager
{

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        ChangePosition();
    }

    private void ChangePosition()
    {
        transform.position = new Vector3(X(), Y());
    }

    private float X()
    {
        return UnityEngine.Random.Range(3, 8)*RandomSign();
    }


    private float Y()
    {
        return UnityEngine.Random.Range(3, 4) * RandomSign();
    }

    private int RandomSign()
    {
        if (UnityEngine.Random.value > 0.5f)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
