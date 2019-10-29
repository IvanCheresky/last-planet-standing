using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipType3 : MonoBehaviour
{
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BasicAmmunitionCollision>().SetDamage(damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
