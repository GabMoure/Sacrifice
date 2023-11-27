using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Local : MonoBehaviour
{
    public int number;
    public bool istp;
    public Quest_Script quest_Script;
   //public GameObject Objective;
   public GameObject Trigger;
   private void OnTriggerEnter(Collider other)
   {
        if (other.CompareTag("Player") && quest_Script.place == true)
        {
            if (number == quest_Script.QuestOrder)
            {
                quest_Script.QuestDone();
                if (istp == false)
                {
                    Trigger.SetActive(false);
                }
            }
        }
   }

}
