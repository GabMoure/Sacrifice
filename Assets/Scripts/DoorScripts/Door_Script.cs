using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Script : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] public string texto;
    [SerializeField] Player_Inventory playerinventory;
    [SerializeField] ShowInteractionText showInteractionText;
    public bool isOpen, inRange;
    public int requiredID;

    public enum PortaEstado
    {
        Aberto,
        Trancado
    }
    public PortaEstado state;
    void Start()
    {
        if (requiredID == 0)
        {
            state = PortaEstado.Aberto;
        }
        else
        {
            state = PortaEstado.Trancado;
        }
    }
    void Update()
    {
        switch(state)
        {
            case PortaEstado.Aberto:
            {
                if (inRange == true)
                {

                    if (Input.GetKeyDown(KeyCode.E))  
                    {
                        ToggleDoor();
                    }      
                }
                break;
            }
            case PortaEstado.Trancado:
            {
                if (inRange == true)
                {
                    if (Input.GetKeyDown(KeyCode.E) && playerinventory.itemsID.Contains(requiredID))  
                    {
                        ToggleDoor();
                        state = PortaEstado.Aberto;
                    }      
                }
                break;
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
    void ToggleDoor()
    {
        isOpen = !isOpen;
        animator.SetBool("Open",isOpen);
    }

}
