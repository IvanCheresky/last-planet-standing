using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkAndTriplicate : MonoBehaviour, Ability
{
    float startingScale;
    public float objectiveScale;
    public float decrement;
    public Triplicate triplicatePrefab;

    private void Start()
    {
        startingScale = transform.localScale.x;
    }

    [SerializeField] private float distance;
    [SerializeField] private float distanceRandom;
    [SerializeField] private float minDistance;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float speed;
    [SerializeField] private float speedRandom;
    public void StartAbility()
    {
        GetComponent<MoveTowardsPlanet>().enabled = true;
        GetComponent<MoveTowardsPlanet>().ReportWhenNextToPlanet(Activate,
            distance + UnityEngine.Random.Range(-distanceRandom, distanceRandom),
            minDistance,
            minY,
            maxY,
            speed + UnityEngine.Random.Range(-speedRandom, speedRandom));
    }

    void Activate()
    {
        GetComponent<MoveTowardsPlanet>().enabled = false;
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        while(transform.localScale.x > objectiveScale)
        {
            transform.localScale = transform.localScale - Vector3.one * decrement;
            yield return null; 
        }

        SpawnTriplicates();
    }

    IEnumerator TransitionBack()
    {
        while (transform.localScale.x < startingScale)
        {
            transform.localScale = transform.localScale + Vector3.one * decrement;
            yield return null;
        }

        GetComponent<MoveTowardsPlanet>().RemoveFromReport(Activate);
        GetComponent<BossType1>().PhaseOver();
    }

    Triplicate triplicate1;
    Triplicate triplicate2;

    private void SpawnTriplicates()
    {
        triplicate1 = Instantiate(triplicatePrefab, transform.position, Quaternion.identity);
        triplicate2 = Instantiate(triplicatePrefab, transform.position, Quaternion.identity);
        triplicate1.transform.localScale = Vector3.one * objectiveScale;
        triplicate2.transform.localScale = Vector3.one * objectiveScale;
        triplicate1.SetSaT(this);
        triplicate2.SetSaT(this);

        triplicate1.MoveUp();
        triplicate2.MoveDown();
    }

    private int destroyedCount = 0;

    internal void OnTriplicateDestroyed()
    {
        if(++destroyedCount < 2)
        {
            return;
        }
        else
        {
            if(this != null)
            {
            StartCoroutine(TransitionBack());
            }
        }
    }

    private int swapCount = 0;

    public void SwapPositions()
    {
        /*check if both are ready to swap, or if one is ready and the other null
         */
        if(++swapCount < 2)
        {
            if (triplicate1 == null || triplicate2 == null)
            {
            }
            else
            {
                return;
            }
        }

        /*don't swap if both are null
        */
        if (triplicate1 == null && triplicate2 == null)
        {
            return;
        }

        /*if one is null, only swap with the other
        */

        else if (triplicate1 == null && triplicate2 != null)
        {
            if (UnityEngine.Random.value < 0.5f)
            {
                SwapTwo(triplicate2);
            }

        }
        else if (triplicate1 != null && triplicate2 == null)
        {
            if (UnityEngine.Random.value < 0.5f)
            {
                SwapTwo(triplicate1);
            }
        }

        /*if none are null, swap between all
        */

        else if (UnityEngine.Random.value < 2/3f)
        {
            {
                if (UnityEngine.Random.value < 0.5f)
                {
                    SwapThree(triplicate1, triplicate2);
                }
                else
                {
                    SwapThree(triplicate2, triplicate1);
                }
            }
        }
    }

    Vector3 stayPosition;
    Vector3 position;

    private void SwapThree(Triplicate triplicate, Triplicate triplicateStay)
    {
        stayPosition = triplicateStay.transform.position; //keeps the position of the unmoved duplicate
        position = transform.position; //saves the position of the real ship
        transform.position = triplicate.transform.position; //sets the position of the real ship as that of the swapped duplicate
        triplicate.transform.position = position; //sets the position of the swapped duplicate as the starting position of the real ship
        triplicateStay.transform.position = stayPosition; //sets the position of the unswapped duplicate as the one it started with

        swapCount = 0;
    }

    private void SwapTwo(Triplicate triplicate)
    {
        position = transform.position; //saves the position of the real ship
        transform.position = triplicate.transform.position; //sets the position of the real ship as that of the swapped duplicate
        triplicate.transform.position = position; //sets the position of the swapped duplicate as the starting position of the real ship

        swapCount = 0;
    }
}
