using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCoord : MonoBehaviour
{
    private Vector2 obj;
    private float speed;

    public Vector2 Obj { get => obj; set => obj = value; }
    public float Speed { get => speed; set => speed = value; }

    internal delegate void objectiveReachedReceiver();
    objectiveReachedReceiver receiver;
    internal void SetObjective(Vector2 obj, float speed, objectiveReachedReceiver receiver)
    {
        this.obj = obj;
        this.speed = speed;
        active = true;
        this.receiver = receiver;
    }

    bool active = false;
    Vector2 direction;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {
            transform.position = Vector2.MoveTowards(transform.position, obj, speed);
            
            Vector2 position = transform.position;
            direction = obj - position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (Vector2.Distance(transform.position, obj) < Mathf.Epsilon)
            {
                active = false;
                receiver();
            }
        }
    }
}
