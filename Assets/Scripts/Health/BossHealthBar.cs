using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    float totalHealth;
    [SerializeField] float bossHealth;
    [SerializeField] Image redBar;
    [SerializeField] Image greenBar;
    float barXSize;
    float maxColor;

    public void SetTotalHealth(float totalHealth)
    {
        this.totalHealth = totalHealth;
        bossHealth = totalHealth;
        barXSize = greenBar.rectTransform.sizeDelta.x;
        maxColor = GetComponent<TextMeshProUGUI>().color.g * 255;
    }

    internal float AddHealth(float health)
    {
        bossHealth += health;

        ChangeText();
        UpdateBars();

        return bossHealth;
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

    public void ChangeText()
    {
        GetComponent<TextMeshProUGUI>().text = bossHealth.ToString() + "/" + totalHealth.ToString();
        GetComponent<TextMeshProUGUI>().color = new Color32((Byte)(maxColor - maxColor * bossHealth / totalHealth), (Byte)(maxColor * bossHealth / totalHealth), 0, 255);
    }

    private void UpdateBars()
    {
        greenBar.rectTransform.sizeDelta = new Vector2(barXSize * bossHealth / totalHealth, greenBar.rectTransform.sizeDelta.y);
    }

}
