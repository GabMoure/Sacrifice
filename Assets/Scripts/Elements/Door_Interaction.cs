using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interaction : MonoBehaviour
{
    [SerializeField] private GameObject UI, UI2;
    [SerializeField] private bool isOpen;
    private Animator animator;
    public bool fresta;
    private bool inRange;
    private bool interact;
    private void Awake()
    {
        isOpen = false;
        fresta = false;
        inRange = false;
        animator = transform.root.GetComponent<Animator>();
    }
    private void Update()
    {
        if (inRange == true)
        {
            Activate();
            if (Input.GetKeyDown(KeyCode.F))
            {
                fresta = !fresta;
                animator.SetBool("Fresta", fresta);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpen = !isOpen;
                animator.SetBool("Open", isOpen);
            }
        }
        else
        {
            if (interact == false)
            {
                Deactivate();
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
