using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorAbility : MonoBehaviour, Ability
{

    GoToCoord goToCoord;

    private void Awake()
    {
        goToCoord = GetComponent<GoToCoord>();
    }

    [SerializeField] private Vector2 startingCoords;
    [SerializeField] private float startingSpeed;
    public void StartAbility()
    {
        goToCoord.SetObjective(startingCoords, startingSpeed, InPositionToStart);
    }

    [SerializeField] private Vector2 abilityCoords;
    [SerializeField] private float abilitySpeed;
    public void InPositionToStart()
    {
        StartCoroutine(StartRotating());
    }

    [SerializeField] private float rotationSpeed;
    IEnumerator StartRotating()
    {
        while (transform.rotation.eulerAngles.z > 270)
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - rotationSpeed);
            yield return null;
        }
        goToCoord.SetObjective(abilityCoords, abilitySpeed, Finished);
    }

    [SerializeField] private int repeats;
    int currentRepeats;
    public void Finished()
    {
        if(++currentRepeats < repeats)
        {
            StartAbility();
        }
        else
        {
            currentRepeats = 0;
            GetComponent<BossType2>().PhaseOver();
        }
    }
}
