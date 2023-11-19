using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrestaScript : MonoBehaviour
{
    public bool inRange;
    private void Awake()
    {
        inRange = false;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Door")
        {
            inRange = true;
        }    
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Door")
        {
            inRange = false;
        }    
    }
}
