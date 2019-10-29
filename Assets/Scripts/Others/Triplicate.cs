using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triplicate : MonoBehaviour
{
    public float offset;
    public float speed;
    float currentOffset;
    ShrinkAndTriplicate sat;

    public void SetSaT(ShrinkAndTriplicate sat)
    {
        this.sat = sat;
    }


    internal void MoveUp()
    {
        StartCoroutine(MoveU(offset));
    }

    internal void MoveDown()
    {
        StartCoroutine(MoveD(-offset));
    }

    IEnumerator MoveU(float offset)
    {
        while(currentOffset < offset)
        {
            currentOffset += speed;
            transform.position = transform.position + Vector3.up * speed;
            yield return null;
        }

        sat.SwapPositions();
    }

    IEnumerator MoveD(float offset)
    {
        while (currentOffset > offset)
        {
            currentOffset -= speed;
            transform.position = transform.position - Vector3.up * speed;
            yield return null;
        }

        sat.SwapPositions();
    }

    private void OnDestroy()
    {
        sat.OnTriplicateDestroyed();
    }
}
