using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetHealthManager : MonoBehaviour
{
    int totalHealth;
    [SerializeField] private int planetHealth;
    ImprovementsManager im;
    [SerializeField] private GameObject hitPanel;
    [SerializeField] private GameObject hitText;
    [SerializeField] private Image redBar;
    [SerializeField] private Image greenBar;
    float barXSize;
    float maxColor;

    private void Awake()
    {
        im = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ImprovementsManager>();
        totalHealth = planetHealth;
        maxColor = GetComponent<TextMeshProUGUI>().color.g * 255;
    }

    internal void AddHealth(float planetHealth)
    {
        AddHealth((int)planetHealth);
    }

    public void Start()
    {
        barXSize = greenBar.rectTransform.sizeDelta.x;
        ChangeText();
    }

    public void AddHealth(int planetHealth)
    {
        if(planetHealth < 0)
        {
            this.planetHealth += planetHealth;
            StartCoroutine(HealthToast(planetHealth, Color.red));
        }
        else
        {
            this.planetHealth += (int)(planetHealth * im.PlanetDefenceMultiplier);
            StartCoroutine(HealthToast(planetHealth, Color.green));
        }

        ChangeText();
        UpdateBars();
    }

    IEnumerator HealthToast(int health, Color color)
    {
        GameObject text = Instantiate(hitText, hitPanel.transform);
        text.GetComponent<TextMeshProUGUI>().text = health.ToString();
        text.GetComponent<TextMeshProUGUI>().color = color;
        yield return new WaitForSeconds(0.5f);
        Destroy(text);
    }

    public void ChangeText()
    {
        GetComponent<TextMeshProUGUI>().text = planetHealth.ToString() + "/" + totalHealth.ToString();
        GetComponent<TextMeshProUGUI>().color = new Color32((Byte)(maxColor - maxColor * Mathf.Min(planetHealth, totalHealth) / totalHealth), (Byte)(maxColor * Mathf.Min(planetHealth, totalHealth) / totalHealth), 0, 255);
    }

    private void UpdateBars()
    {
        greenBar.rectTransform.sizeDelta = new Vector2(barXSize * planetHealth / totalHealth, greenBar.rectTransform.sizeDelta.y);
    }
}
