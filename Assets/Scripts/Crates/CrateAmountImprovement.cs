using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateAmountImprovement : MonoBehaviour
{
    ImprovementsManager im;

    private void Start()
    {
        im = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ImprovementsManager>();
    }

    public void OnClick()
    {
        im.OnCrateAmountImprovement();
    }
}
