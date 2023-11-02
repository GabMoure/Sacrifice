using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interaction : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    private bool isOpen;

    private void Awake()
    {
        isOpen = false;
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
