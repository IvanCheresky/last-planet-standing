using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarHolder : MonoBehaviour, HealthHolder
{
    [SerializeField] private GameObject healthBar;
    GameObject healBarInst;
    [SerializeField] private float offset;
    [SerializeField] private float totalHealth;
    float currentHealth;

    private void Awake()
    {
        healBarInst = Instantiate(healthBar, null);
        healBarInst.GetComponent<HealthBar>().ToFollow(transform, offset, totalHealth); //sets the gameobject the healthbar will follow and its offset
        currentHealth = totalHealth;
    }

    void OnDestroy()
    {
        if(healBarInst != null)
        {
            Destroy(healBarInst);
        }
    }

    public void Damage(float tapDamage)
    {
        currentHealth -= tapDamage;

        if (currentHealth < 0)
        {
            GetComponent<Destroyer>().OnDestroyShip();
        }

        healBarInst.GetComponent<HealthBar>().Damage(tapDamage);
    }

    public void Show()
    {
        healBarInst.GetComponent<HealthBar>().Show();
    }

    public void Hide()
    {
        healBarInst.GetComponent<HealthBar>().Hide();
    }
}
