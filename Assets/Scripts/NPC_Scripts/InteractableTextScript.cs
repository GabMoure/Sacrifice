using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableTextScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI container;
    [SerializeField] private Player_Inventory player_Inventory;
    [SerializeField] private Interact interact;
    [HideInInspector] public GameObject textobject;
    
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
        Item_Script itemscript = textobject.GetComponent<Item_Script>();
        container.text = itemscript.texto;

    }
    private void Hide()
    {
        container.text = "";
        textobject = null;
    }
}
