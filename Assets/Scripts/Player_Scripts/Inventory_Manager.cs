using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Manager : MonoBehaviour
{
    [SerializeField] Player_Inventory player_inventory;
    [SerializeField] GameObject Ui;
    private bool inRange;
    public GameObject item;
    
    void Start()
    {
        player_inventory.inventoryList = new List<GameObject>();
    }

    void Update()
    {
        if (inRange == true & Input.GetKeyDown(KeyCode.E))
        {
            if (player_inventory.inventoryList.Count < player_inventory.MaxInventory)
            {
                player_inventory.inventoryList.Add(item);
                item = null;
            }
            else
            {
                Debug.Log("TOO MUCH");
            }            
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Item")
        {
            Ui.SetActive(true);
            inRange = true;
            item = collider.gameObject;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Item")
        {
            Ui.SetActive(false);
            inRange = false;
            item = null;
        }
    }
}
