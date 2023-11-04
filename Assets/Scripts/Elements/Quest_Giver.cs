using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Giver : MonoBehaviour
{
    public int n;
    public int names;
    private Quest_Script questScript;
    void Start()
    {
        questScript = GetComponent<Quest_Script>();
        n = 0;
        questScript.QuestRecieve(n);
    }
    void Update()
    {

        switch(n)
        {
            case 0:
            {
                names = 0;
                break;
            }
            case 1:
            {
                questScript.QuestDone(n);
                names = 1;
                break;
            }
            case 2:
            {
                questScript.QuestDone(n);
                break;
            }
        }
    }
}
