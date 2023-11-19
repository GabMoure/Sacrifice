using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interaction : MonoBehaviour
{
    [SerializeField] private GameObject UI, UI2;
    [SerializeField] private bool isOpen;
    private Animator animator;
    [SerializeField] FrestaScript frestaScript;
    public bool fresta;
    private bool interact;
    private void Awake()
    {
        isOpen = false;
        fresta = false;
        animator = transform.root.GetComponent<Animator>();
    }
    private void Update()
    {
        if (frestaScript.inRange == true)
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
