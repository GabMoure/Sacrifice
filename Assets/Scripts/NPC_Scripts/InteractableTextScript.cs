using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableTextScript : ShowInteractionText
{
    [SerializeField] private Player_Inventory player_Inventory;
    [SerializeField] private Interact interact;
    private string text = "(E)";
    
    private void Update()
    {
        if (interact.GetInteractable() != null || player_Inventory.isitem == true)
        {
            base.Show(text);
        }
        else
        {
            base.Hide();
        }
    }
   
}
