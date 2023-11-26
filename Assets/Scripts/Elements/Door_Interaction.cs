using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interaction : MonoBehaviour
{
    [SerializeField] private GameObject UI, UI2;
    [SerializeField] private bool isOpen;
    [SerializeField] private int IDrequired;
    [SerializeField] Player_Inventory player_Inventory;
    [SerializeField] PlayerMovement player_movement;
    enum estado
    {
        open,
        closed,
    }
    private Animator animator;
    public bool fresta;
    private bool inRange;
    public bool gustavo;
    private bool interact;
    private estado state;
    private void Awake()
    {
        isOpen = false;
        fresta = false;
        inRange = false;
        animator = transform.root.GetComponent<Animator>();
    }
    private void Start()
    {
        if (IDrequired == 0)
        {
            state = estado.open;
        }
        else
        {
            state = estado.closed;
        }
    }
    private void Update()
    {
        if (inRange == true)
        {
            Activate();    
        }
        else
        {
            if (interact == false)
            {
                Deactivate();
            }

        }
        switch(state)
        {
            case estado.open:
            {  
                if (inRange == true || gustavo == true)
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        fresta = !fresta;
                        animator.SetBool("Fresta", fresta);
                        if (fresta == true)
                        {
                            gustavo = true;
                        }
                        else
                        {
                            gustavo = false;
                        }
                    }
                }
                if (inRange == true && Input.GetKeyDown(KeyCode.E))
                {
                    isOpen = !isOpen;
                    animator.SetBool("Open", isOpen);
                }
                break;
            }
            case estado.closed:
            {
                if (player_Inventory.itemsID.Contains(IDrequired))
                {
                    state = estado.open;
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
            player_movement.door_interaction = GetComponent<Door_Interaction>();
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            inRange = false;
            player_movement.door_interaction = null;
        }
    }
    void Activate()
    {
        UI.SetActive(true);
        UI2.SetActive(true);
        interact = false;
    }
    void Deactivate()
    {
        UI.SetActive(false);
        UI2.SetActive(false);
        interact = true;
    }
    /*
    public void Doorchange()
    {   
        isOpen = !isOpen;
        animator.SetBool("Open", isOpen);
    }
    /*
    public void Interacion(Transform interactor)
    {
        Doorchange();
    }*/
}
