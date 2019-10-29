using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipType10 : MonoBehaviour
{
    Vector3 planetPosition;
    bool skullActive;
    GameObject skull;
    WaitForSeconds skullCycle = new WaitForSeconds(5f);

    // Start is called before the first frame update
    void Start()
    {
        planetPosition = GameObject.FindGameObjectWithTag("Planet").transform.position;
        skull = transform.GetChild(0).gameObject;
        skullActive = true;
        StartCoroutine(UpdateSkull());
    }

    IEnumerator UpdateSkull()
    {
        while (true)
        {
            skullActive = !skullActive;
            skull.SetActive(skullActive);
            yield return skullCycle;
        }
        
    }

    public bool Skull()
    {
        return skullActive;
    }
}
