using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest_Script : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI quest;
    [SerializeField] private GameObject container;
    public string[] text = {"Fale com Carolis.", "Fale com Kaio.", "Volte para o quarto."};
    public bool isActive;

    public void QuestRecieve(int questnumber)
    {
        isActive = true;
        container.SetActive(true);
        quest.text = text[questnumber];
    }

    public void QuestDone(int newnumber)
    {
        if (newnumber <= text.Length)
        {
            QuestRecieve(newnumber);          
        }
        else
        {
            isActive = false;
            container.SetActive(false);
        }

    }
}
