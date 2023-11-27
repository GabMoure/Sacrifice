using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeleport : MonoBehaviour
{
    [SerializeField] Transform complete;
    [SerializeField] Transform enemytransform;
    [SerializeField] EnemyScript enemyscript;
    private bool done;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && done == false)
        {
            StartCoroutine(EnemySpawn());
            done = true;
        }
    }
    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(5);
        enemytransform.position = complete.position;
        enemyscript.chasing = true;
        enemyscript.walking = false;
        yield return new WaitForSeconds(5);
        complete.gameObject.SetActive(false);
        //enemyscript.StartCoroutine(ChaseRoutine());
    }
}
