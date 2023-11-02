using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Interaction : MonoBehaviour, IInteractable
{
    private int c;
    [Header("Falas")]
    [SerializeField] TextMeshProUGUI chattext;
    [SerializeField] GameObject Ui;
    [SerializeField] List<string> fala;

   /* private int currentIndex;
    private WaitForSeconds Delay;
    private WaitForSeconds PunctuationDelay;
*/


    private void Awake()
    {
        c = 0;
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
        }
    }
}