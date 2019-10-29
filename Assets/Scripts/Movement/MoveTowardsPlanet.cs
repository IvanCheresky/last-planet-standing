using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlanet : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] float minDistance;
    [SerializeField] float minX = -9;
    [SerializeField] float maxX = 9;
    [SerializeField] float minY = -5;
    [SerializeField] float maxY = 5;
    [SerializeField] float speed;
    Transform planet;

    public float MaxDistance { get => maxDistance; set => maxDistance = value; }
    public float MinDistance { get => minDistance; set => minDistance = value; }
    public float MinX { get => minX; set => minX = value; }
    public float MaxX { get => maxX; set => maxX = value; }
    public float MinY { get => minY; set => minY = value; }
    public float MaxY { get => maxY; set => maxY = value; }
    public float Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsMoving())
        {
            if(Vector2.Distance(transform.position, planet.position) >= MaxDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, planet.position, speed);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, planet.position, -speed);
            }
        }
        else
        {
            if (IsOutsideXBound())
            {
                if(transform.position.x < minX)
                {
                    transform.position = transform.position - Vector3.left * speed;
                }
                else
                {
                    transform.position = transform.position - Vector3.right * speed;
                }
            }
            else if (IsOutsideYBound())
            {
                if (transform.position.y < minY)
                {
                    transform.position = transform.position - Vector3.down * speed;
                }
                else
                {
                    transform.position = transform.position - Vector3.up * speed;
                }

            }
            else
            {
                SendReport();
            }
        }
    }

    public bool IsMoving()
    {
        return (Vector2.Distance(transform.position, planet.position) >= MaxDistance) || (Vector2.Distance(transform.position, planet.position) <= MinDistance);
    }

    public bool IsOutsideXBound()
    {
        return (transform.position.x < minX) || (transform.position.x > maxX);
    }

    public bool IsOutsideYBound()
    {
        return (transform.position.y < minY) || (transform.position.y > maxY);
    }

    public delegate void MessageReceiver();
    List<MessageReceiver> delegateList = new List<MessageReceiver>();

    public void ReportWhenNextToPlanet(MessageReceiver function, float maxDistance, float minDistance, float minY, float maxY, float speed)
    {
        this.minY = minY;
        this.maxY = maxY;
        this.maxDistance = maxDistance;
        this.minDistance = minDistance;
        this.speed = speed;
        delegateList.Add(function);
    }

    public void ReportWhenNextToPlanet(MessageReceiver function, float maxDistance, float minDistance, float speed)
    {
        this.maxDistance = maxDistance;
        this.minDistance = minDistance;
        this.speed = speed;
        delegateList.Add(function);
    }

    public void ReportWhenNextToPlanet(MessageReceiver function, float maxDistance, float speed)
    {
        this.maxDistance = maxDistance;
        minDistance = 0;
        this.speed = speed;
        delegateList.Add(function);
    }

    public void ReportWhenNextToPlanet(MessageReceiver function, float maxDistance)
    {
        this.maxDistance = maxDistance;
        minDistance = 0;
        delegateList.Add(function);
    }

    public void ReportWhenNextToPlanet(MessageReceiver function)
    {
        delegateList.Add(function);
    }

    public void RemoveFromReport(MessageReceiver function)
    {
        delegateList.Remove(function);
    }

    private void SendReport()
    {
        foreach (MessageReceiver receiver in delegateList)
        {
            receiver();
        }

        delegateList.Clear();
    }
}
