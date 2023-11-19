using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDifferent : MonoBehaviour
{
    public bool doorState = false;
    public Transform view;
    public float interaction_distance;
    void Start()
    {

    }

    void Update()
    {
        Ray ray = new Ray(view.position, view.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interaction_distance))
        {
            if (hit.collider.gameObject.tag == "door")
            {
                GameObject door = hit.collider.transform.root.gameObject;
                Animator animacao = door.GetComponent<Animator>();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    doorState = !doorState;
                    animacao.SetBool("DoorState", doorState);
                }
            }
        }
    }
}
