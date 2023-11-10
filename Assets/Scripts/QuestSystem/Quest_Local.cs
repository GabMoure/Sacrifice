using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Local : MonoBehaviour
{
    
    public Quest_Script quest_Script;
   //public GameObject Objective;
   public GameObject Trigger;
   private void OnTriggerEnter(Collider other)
   {
        if (other.CompareTag("Player") && quest_Script.place == true)
        {
            quest_Script.QuestDone();
            Trigger.SetActive(false);
        }
   }

}
