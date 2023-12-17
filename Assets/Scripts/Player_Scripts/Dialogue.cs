using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject container;
    public TextMeshProUGUI text;
    public int c;
    public int general;
    public List<int> eventlist = new List<int>();
    public List<int> dialoguelimit = new List<int>();
    public List<string> dialogues = new List<string>();
    public QuestOrder questOrder;
    private PlayerMovement player_movement;

    void Start()
    {        
        c = 0;
        general = questOrder.generalOrder;
        player_movement = GetComponent<PlayerMovement>();
    }   
    void Update()
    {
        if (eventlist.Contains(general))
        {
            QuestDialogue(dialoguelimit[questOrder.generalOrder]);
        }
        else
        {
            container.SetActive(false);
            text.text = "";
        }
    } 

    void QuestDialogue(int n)
    {
        player_movement.Switch(0);
        container.SetActive(true);
        if (c < n)
        {
            text.text = dialogues[c];
            if (Input.GetKeyDown(KeyCode.E) && c <= n)
            {
                c++;
            }
        }
        else
        {
            player_movement.Switch(1);
            c = 0;
            general++;
        }
    }
}
