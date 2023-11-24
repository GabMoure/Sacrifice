using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] NavMeshAgent ai;
    [SerializeField] List<Transform> destinations;
    [SerializeField] List<Transform> CanonEvents;
    [SerializeField] Animator anim;
    [SerializeField] float Walkspeed,Runspeed, minIdleTime, maxIdleTime, IdleTime;
    [SerializeField] Transform Player;
    [SerializeField] int DestinationAmount;
    private Vector3 Direction;
    private int randNum, randNum2;
    private Transform currentDestination;
    private bool walking, chasing;

    void Start()
    {
        walking = true;
        randNum = Random.Range(0, DestinationAmount);
        currentDestination = destinations[randNum];
    }
    void Update()
    {
        if (walking == true)
        {
            Direction = currentDestination.position;
            ai.destination = Direction;
            ai.speed = Walkspeed;
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                randNum2 = Random.Range(0,1);
                if (randNum2 == 0)
                {
                    randNum = Random.Range(0, DestinationAmount);
                    currentDestination = destinations[randNum];
                }
                if (randNum == 1)
                {
                    anim.ResetTrigger("walk");
                    anim.SetTrigger("idle");
                    StartCoroutine(StayIdle());
                    walking = false;
                }
            }
        }
    }
    IEnumerator StayIdle()
    {
        IdleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(IdleTime);
        randNum = Random.Range(0, DestinationAmount);
        currentDestination = destinations[randNum];
        anim.ResetTrigger("idle");
        anim.SetTrigger("walk");
        walking = true;
    }
}
