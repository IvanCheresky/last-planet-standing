using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ImprovementsManager : MonoBehaviour
{
    private float tapDamage;
    private float tapDamageMultiplier;
    private float planetDefenceMultiplier;
    private float healthFromCratesMultiplier;
    private float healthCratesMultiplier;


    public float TapDamageMultiplier { get => tapDamageMultiplier; set => tapDamageMultiplier = value; }
    public float PlanetDefenceMultiplier { get => planetDefenceMultiplier; set => planetDefenceMultiplier = value; }
    public float HealthFromCratesMultiplier { get => healthFromCratesMultiplier; set => healthFromCratesMultiplier = value; }
    public float HealthCratesMultiplier { get => healthCratesMultiplier; set => healthCratesMultiplier = value; }
    //TEMPORARY IMMUNITY
    //

    // Start is called before the first frame update
    void Start()
    {
        tapDamage = 400;
        tapDamageMultiplier = 1;
        planetDefenceMultiplier = 1;
        healthFromCratesMultiplier = 1;
        healthCratesMultiplier = 1;
    }

    public float GetDamage()
    {
        return tapDamage * tapDamageMultiplier;
    }

    public GameObject improvementsUI;
    public List<GameObject> improvements;

    internal void OnLevelOver()
    {
        improvementsUI.SetActive(true);

        List<int> indexes = GenerateRandom(3, 0, improvements.Count - 1);

        GameObject improvement = Instantiate(improvements[indexes[0]], improvementsUI.transform);

        GameObject improvement2 = Instantiate(improvements[indexes[1]], improvementsUI.transform);

        GameObject improvement3 = Instantiate(improvements[indexes[2]], improvementsUI.transform);

    }

    internal void OnTapImprovement()
    {
        tapDamageMultiplier += 0.1f;
        ResumeGame();
    }

    internal void OnDefenceImprovement()
    {
        planetDefenceMultiplier += 0.1f;
        ResumeGame();
    }

    internal void OnCratesImprovement()
    {
        healthCratesMultiplier += 0.08f;
        ResumeGame();
    }

    internal void OnCrateAmountImprovement()
    {
        healthCratesMultiplier += 0.12f;
        ResumeGame();
    }

    internal void OnPlanetHealingImprovement()
    {
        GameObject.FindGameObjectWithTag("PlanetHealth").GetComponent<PlanetHealthManager>().AddHealth(3000);
    }

    void ResumeGame()
    {
        foreach(Transform child in improvementsUI.transform)
        {
            Destroy(child.gameObject);
        }

        improvementsUI.SetActive(false);
        GetComponent<LevelManager>().StartGame();
    }


    static System.Random random = new System.Random();
    static HashSet<int> candidates = new HashSet<int>();

    public static List<int> GenerateRandom(int count, int min, int max)
    {
        if (max <= min || count < 0 ||
                (count > max - min && max - min > 0))
        {
            throw new ArgumentOutOfRangeException("Range " + min + " to " + max +
                    " (" + ((Int64)max - (Int64)min) + " values), or count " + count + " is illegal");
        }

        for (int top = max - count; top < max; top++)
        {
            if (!candidates.Add(random.Next(min, top + 1)))
            {
                candidates.Add(top);
            }
        }

        List<int> result = candidates.ToList();
        candidates.Clear();

        for (int i = result.Count - 1; i > 0; i--)
        {
            int k = random.Next(i + 1);
            int tmp = result[k];
            result[k] = result[i];
            result[i] = tmp;
        }
        return result;
    }
    
}
