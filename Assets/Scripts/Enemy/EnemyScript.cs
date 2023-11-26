using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] NavMeshAgent ai;
    [SerializeField] List<Transform> destinations;
    [SerializeField] List<Transform> CanonEvents;
    [SerializeField] Animator anim;
    [SerializeField] float Walkspeed,Runspeed, minIdleTime, maxIdleTime, IdleTime, raycastDistance, 
    minChaseTime, maxChaseTime, ChaseTime, jumpscareTime;
    [SerializeField] Transform Player;
    [SerializeField] int DestinationAmount;
    [SerializeField] GameObject PlayerCamera;
    private Vector3 Direction;
    private int randNum, randNum2;
    private Transform currentDestination;
    private bool walking, chasing;

    void Start()
    {
        walking = true;
        chasing = false;
        randNum = Random.Range(0, DestinationAmount);
        currentDestination = destinations[randNum];
    }
    void Update()
    {
        Vector3 towardsDirection = (Player.position - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, towardsDirection, out hit, raycastDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                walking = false;
                StopCoroutine(StayIdle());
                StartCoroutine(ChaseRoutine());
                //setting run trigger
                anim.ResetTrigger("idle");
                anim.ResetTrigger("walk");
                anim.SetTrigger("chase");
                //boolean
                chasing = true;
            }
        }

        if (walking == true)
        {
            Direction = currentDestination.position;
            ai.destination = Direction;
            ai.speed = Walkspeed;
            anim.SetTrigger("walk");
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
                }
            }
            ai.updateRotation = true;
        }
        
        if (chasing == true)
        {
            Direction = Player.position;
            ai.destination = Direction;
            ai.speed = Runspeed;
            ai.updateRotation = true;
        }
    }
    IEnumerator StayIdle()
    {
        IdleTime = Random.Range(minIdleTime, maxIdleTime);
        ai.updateRotation = false;
        walking = false;
        yield return new WaitForSeconds(IdleTime);
        randNum = Random.Range(0, DestinationAmount);
        currentDestination = destinations[randNum];
        anim.ResetTrigger("idle");
        anim.SetTrigger("walk");
        walking = true;
        ai.updateRotation = true;
    }

    IEnumerator ChaseRoutine()
    {
        ChaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(ChaseTime);
        randNum = Random.Range(0, DestinationAmount);
        currentDestination = destinations[randNum];
        anim.ResetTrigger("chase");
        anim.SetTrigger("walk");
        chasing = false;
        walking = true;
        ai.updateRotation = true;
    }
    IEnumerator KillPlayer()
    {
        yield return new WaitForSeconds(jumpscareTime);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(chasing == true && collider.gameObject.tag == "Player")
        {
            anim.ResetTrigger("chase");
            PlayerCamera.SetActive(false);
            anim.SetTrigger("kill");
            StartCoroutine(KillPlayer());
            chasing = false;
        }
    }
}
