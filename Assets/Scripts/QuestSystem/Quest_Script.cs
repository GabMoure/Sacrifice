using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest_Script : MonoBehaviour
{
    [Header("Type")]
    [SerializeField] private TextMeshProUGUI quest;
    [SerializeField] private GameObject container;

    [Header("QuestTypes")]
    public bool place, convo, item;

    public string[] text = {"Fale com Carolis.", "Fale com Kaio.", "Volte para o quarto."};
    public List<int> Localnumbers = new List<int>();
    public int QuestOrder;
    public enum QuestType
    {
        Conversa,
        Local,
        Item
    }
    public static QuestType currenttype;

    private void Awake()
    {
        QuestOrder = 0;
        currenttype = QuestType.Conversa;
        QuestGive(QuestOrder);
    }
    public void QuestGive(int qnumber)
    {
        container.SetActive(true);
        if (qnumber < text.Length)
        {
            quest.text = text[qnumber];
        }

        QuestSelectType(qnumber);

        switch(currenttype)
        {
           case QuestType.Conversa:
           {
                place = false;
                convo = true;
                item = false;
                break;
           } 
           case QuestType.Local:
           {
                place = true;
                convo = false;
                item = false;    
                break;
           }
           case QuestType.Item:
           {
                place = false;
                convo = false;
                item = true;
                break;
           }
        }
    }
    public void QuestDone()
    {
        QuestOrder++;
        if (QuestOrder >= text.Length)
        {
            container.SetActive(false);
        }
        else
        {
            QuestGive(QuestOrder);
        }
    }
    public void QuestSelectType(int number)
    {
        if (Localnumbers.Contains(number))
        {
            currenttype = QuestType.Local;
        }
    }
}

