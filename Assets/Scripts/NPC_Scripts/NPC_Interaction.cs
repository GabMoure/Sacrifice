using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Interaction : MonoBehaviour
{
    public Transform Player;
    public float raycastDistance;
    public int number;
    public int c;

    public bool inRange;

    string[] nameArray = {"Carolis", "Kaio", ""};

    [Header("Falas")]
    [SerializeField] TextMeshProUGUI chattext;
    [SerializeField] GameObject Ui;
    [SerializeField] List<string> fala;

    //[Header("Quests")]
    //[SerializeField] Quest_Script quest_Script;

   /* private int currentIndex;
    private WaitForSeconds Delay;
    private WaitForSeconds PunctuationDelay;
    */


    private void Awake()
    {
        c = 0;
    }
    private void Update()
    {
        Vector3 towardsDirection = (Player.position - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, towardsDirection, out hit, raycastDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                inRange = true;
            }
        }

        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            Speak();
        }
    }
    public void Speak()
    {
            Ui.SetActive(true);
            if (c <= fala.Count)
            {
                chattext.text = fala[c];
            }
            else
            {
            Ui.SetActive(false);
                chattext.text = null;
                    /*
                    if (quest_Script.QuestOrder == number)
                    {
                        quest_Script.QuestDone();
                    }*/
            }
    }
}
