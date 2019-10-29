using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    Transform toFollow;
    public Transform greenBar;
    public Transform redBar;
    Vector3 offset;
    float health;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = toFollow.position + offset;
    }

    internal void ToFollow(Transform toFollow, float offset, float health)
    {
        this.toFollow = toFollow;
        this.offset = Vector3.up * offset;
        this.health = health;
    }

    internal void Damage(float tapDamage)
    {
        greenBar.localScale -= Vector3.right * (tapDamage / health) * redBar.localScale.x ;
    }

    public void Show()
    {
        greenBar.GetComponent<SpriteRenderer>().enabled = true;
        redBar.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Hide()
    {
        greenBar.GetComponent<SpriteRenderer>().enabled = false;
        redBar.GetComponent<SpriteRenderer>().enabled = false;
    }

}
