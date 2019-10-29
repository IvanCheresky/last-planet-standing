using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleShipMover : MonoBehaviour
{
    [SerializeField] List<Vector3> points = new List<Vector3>();
    protected Vector3 point;
    float distance;
    [SerializeField] float speed;
    protected bool pointReached;
    Transform planet;

    // Start is called before the first frame update
    protected void Start()
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
            if(distance == 0 || (Vector3.Distance(transform.position, p) > Mathf.Epsilon && Vector3.Distance(transform.position, p) < distance))
            {
                distance = Vector3.Distance(transform.position, p);
                point = p;
            }
        }
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, point, speed);

        if(Vector3.Distance(transform.position, point) < Mathf.Epsilon && !pointReached)
        {
            pointReached = true;
            GetComponent<Animator>().Play("Turn Visible");
            GetComponent<HealthHolder>().Show();
            if (GetComponent<ShipType4>())
            {
                GetComponent<ShipType4>().OnPointReached();
            }else if(GetComponent<BossType2>()){
                GetComponent<BossType2>().OnPointReached();
            }
        }

        if (!pointReached)
        {
            Rotator(point);
        }
        else
        {
            Rotator(planet.position);
        }
    }

    private Vector3 direction;

    void Rotator(Vector3 obj)
    {
        direction = obj - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
