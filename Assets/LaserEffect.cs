using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEffect : MonoBehaviour
{
    protected LineRenderer lineRenderer;
    protected Transform planet;

    protected virtual void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
    }

    private void OnEnable()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, planet.position);
    }
}
