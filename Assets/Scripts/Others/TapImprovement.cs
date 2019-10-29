using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapImprovement : MonoBehaviour
{
    ImprovementsManager im;

    private void Start()
    {
        im = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ImprovementsManager>();
    }

    public void OnClick()
    {
        im.OnTapImprovement();
    }
}
