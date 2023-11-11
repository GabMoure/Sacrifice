using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interaction : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    private bool inRange;
    [SerializeField] private bool isOpen;
    [SerializeField] private bool fresta;

    private void Awake()
    {
        isOpen = false;
        fresta = false;
    }
    private void Update()
    {

    }
    public void Doorchange()
    {   
        isOpen = !isOpen;
        animator.SetBool("Open", isOpen);
    }
    public void Interacion(Transform interactor)
    {
        Doorchange();
    }
}
