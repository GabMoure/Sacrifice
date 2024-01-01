using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note_Item : MonoBehaviour
{
    [SerializeField] GameObject container;
    [SerializeField] PlayerMovement playerMovement;
    public bool alternate;
    void Start()
    {
        container.SetActive(false);
    }
    void Update()
    {
        if (alternate == true)
        {
            Read();
        }
        else
        {
            Unread();
        }
    }

    public void Read()
    {
        playerMovement.isStoped = true;
        container.SetActive(true);
    }
    public void Unread()
    {
        playerMovement.isStoped = false;
        container.SetActive(false);
    }
}
