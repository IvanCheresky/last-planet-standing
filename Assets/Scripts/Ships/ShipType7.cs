using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipType7 : MonoBehaviour
{
    [SerializeField] List<Vector3> points = new List<Vector3>();
    Vector3 point;
    Transform planet;
    [SerializeField] float speed;
    bool pointReached;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
        SetPoint();
    }

    public void SetPoint()
    {
        pointReached = false;
        distance = 0;

        foreach (Vector3 p in points)
        {
            if (distance == 0 || (Vector3.Distance(transform.position, p) > Mathf.Epsilon && Vector3.Distance(transform.position, p) < distance))
            {
                distance = Vector3.Distance(transform.position, p);
                point = p;
            }
        }
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, point, speed);

        if (Vector3.Distance(transform.position, point) < Mathf.Epsilon && !pointReached)
        {
            pointReached = true;
            GetComponentInChildren<LineRenderer>().enabled = true;
            foreach (LineRenderer lineRenderer in GetComponentsInChildren<LineRenderer>())
            {
                lineRenderer.enabled = true;
            }
            GetComponentInChildren<LaserBeam>().enabled = true;
            foreach (LaserEffect laser in GetComponentsInChildren<LaserEffect>())
            {
                laser.enabled = true;
            }
        }

    }
}
