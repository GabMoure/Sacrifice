using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public bool range = false;
    void OnTriggerEnter(Collider colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            range = true;
        }
    }
    void OnTriggerExit(Collider colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            range = false;
        }
    }
}
