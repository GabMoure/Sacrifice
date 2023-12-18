using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public GameObject container;
    public TextMeshProUGUI text;
    public int c;
    private int g;
    public int general;
    public List<int> eventlist = new List<int>();
    public List<int> dialoguelimit = new List<int>();
    public List<string> dialogues = new List<string>();
    public QuestOrder questOrder;
    private PlayerMovement player_movement;
    Scene currentscene;

    void Start()
    {   
        g = 0;     
        c = 0;
        general = questOrder.generalOrder;
        player_movement = GetComponent<PlayerMovement>();
        questOrder = GameObject.Find("ContainerOrder").GetComponent<QuestOrder>();
        currentscene = SceneManager.GetActiveScene();
    }   
    void Update()
    {
        c = questOrder.armazen;
        Scene actualscene = SceneManager.GetActiveScene();
        if (currentscene != actualscene)
        {
            questOrder = GameObject.Find("ContainerOrder").GetComponent<QuestOrder>();
            general = questOrder.generalOrder;
            currentscene = SceneManager.GetActiveScene();
        }
        if (eventlist.Contains(general))
        {
            QuestDialogue(dialoguelimit[g]);
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
                questOrder.armazen = c;
            }
        }
        else
        {
            player_movement.Switch(1);
            general++;
            g++;
        }
    }
}
