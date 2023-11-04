using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Interaction : MonoBehaviour, IInteractable
{
    private int c;

    [Header ("nome")]
    public int nome;
    public string name;
    string[] nameArray = {"Carolis", "Kaio"};

    [Header("Falas")]
    [SerializeField] TextMeshProUGUI chattext;
    [SerializeField] GameObject Ui;
    [SerializeField] List<string> fala;

    [Header("Quests")]
    [SerializeField] Quest_Giver quest_Giver;

   /* private int currentIndex;
    private WaitForSeconds Delay;
    private WaitForSeconds PunctuationDelay;
*/


    private void Awake()
    {
        c = 0;
        name = nameArray[nome];
    }
    public void Interacion(Transform interactor)
    {
        Ui.SetActive(true);
        if (c < fala.Count)
        {
            chattext.text = fala[c];
            c++;
        }
        else
        {
            c = 0;
            Ui.SetActive(false);
            chattext.text = null;
            if (nome == quest_Giver.names)
            {
                quest_Giver.n++;
            }            
        }
    }
}
