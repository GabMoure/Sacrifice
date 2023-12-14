using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestOrder : MonoBehaviour
{
    public int generalOrder;
}


public class Quest_Script1 : QuestOrder
{
    public string questType;
    public int OrderID;
    public int requiredItemID;
    public bool isDone;
    public Quest quest;
    
    void OnEnable()
    {
        questType = quest.questType;
        OrderID = quest.OrderID;
        requiredItemID = quest.requiredItemID;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (OrderID == base.generalOrder)
            {
                isDone = true;
                base.generalOrder++;
                Debug.Log("Completed");
            }
        }
    }
}



