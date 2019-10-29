using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBarHolder : MonoBehaviour, HealthHolder
{
    [SerializeField] GameObject healthBar;
    GameObject healBarInst;
    BossHealthBar bossHealthBar;
    [SerializeField] float bossHealth;

    private void Awake()
    {
        healBarInst = Instantiate(healthBar, null);
        bossHealthBar = healBarInst.GetComponentInChildren<BossHealthBar>();
        bossHealthBar.SetTotalHealth(bossHealth);
    }
    

    void OnDestroy()
    {
        if (healBarInst != null)
        {
            Destroy(healBarInst);
        }
    }

    public void Damage(float tapDamage)
    {
        if(bossHealthBar.AddHealth(-tapDamage) < 0)
        {
            GetComponent<Destroyer>().OnDestroyShip();
        }

    }

    public void Show()
    {
        //bossHealthBar.Show();
    }

    public void Hide()
    {
        //bossHealthBar.Hide();
    }
}
