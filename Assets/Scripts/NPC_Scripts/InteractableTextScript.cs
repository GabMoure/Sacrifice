using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTextScript : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private Player_Inventory player_Inventory;
    [SerializeField] private Interact interact;
    private void Update()
    {
        if (interact.GetInteractable() != null || player_Inventory.isitem == true)
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
