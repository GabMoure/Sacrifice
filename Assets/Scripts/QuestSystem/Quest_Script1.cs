using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest_Script1 : MonoBehaviour
{
    public string questType;
    public int OrderID;
    public int requiredItemID;
    public bool isDone;
    public Quest quest;
    public Player_Inventory player_Inventory;
    public QuestOrder questOrder;

    void OnEnable()
    {
        questType = quest.questType;
        OrderID = quest.OrderID;
        requiredItemID = quest.requiredItemID;
    }

    void Update()
    {
        if (player_Inventory.itemsID.Contains(requiredItemID) && questType == "item")
        {
            if (OrderID == questOrder.generalOrder)
            {
                questOrder.generalOrder++;
                Debug.Log("Completed");  
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (OrderID == questOrder.generalOrder && questType == "local")
            {
                questOrder.generalOrder++;
                Debug.Log("Completed");
            }
        }
    }
}



