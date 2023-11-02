using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTextScript : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private Interact interact;
    private void Update()
    {
        if (interact.GetInteractable() != null)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Show()
    {
        container.SetActive(true);
    }
    private void Hide()
    {
        container.SetActive(false);
    }
}
