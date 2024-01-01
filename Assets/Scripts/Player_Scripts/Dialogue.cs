using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] List<string> dialoguelist = new List<string>();
    [SerializeField] List<string> dialogue2 = new List<string>();
    [SerializeField] GameObject container;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Locker_Script locker_script;
    private PlayerMovement playerMovement;
    public int c,lvl;
    private bool changed,area1;

    void Start()
    {
        c = 0;
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
       if (lvl == 0 || area1 == true)
       {
            Talk();
       }

       if (locker_script.isActive == true)
       {
            playerMovement.isStoped = true;
       }
    }  
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "area1")
        {
            if (area1 == false && lvl == 1)
            {
                c = 0;
                changed = false;
                area1 = true;
            }
        }
    }
    void Talk()
    {
        if (lvl == 0)
        {
            if (c < dialoguelist.Count)
            {
                playerMovement.isStoped = true;
                container.SetActive(true);
                text.text = dialoguelist[c];
                if (Input.GetKeyDown(KeyCode.E))
                {
                    c++;
                }
            }
            else
            {
                if (changed == false)
                {
                    playerMovement.isStoped = false;
                    container.SetActive(false);
                    text.text = "";
                    changed = true;
                    lvl++;
                    area1 = false;
                }
            }
        }
        if (area1 == true)
        {
             if (c < dialogue2.Count)
            {
                playerMovement.isStoped = true;
                container.SetActive(true);
                text.text = dialogue2[c];
                if (Input.GetKeyDown(KeyCode.E))
                {
                    c++;
                }
            }
            else
            {
                if (changed == false)
                {
                    playerMovement.isStoped = false;
                    container.SetActive(false);
                    text.text = "";
                    changed = true;
                    lvl++;
                    area1 = false;
                }
            }
        }
    }
}
