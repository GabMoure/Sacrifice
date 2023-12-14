using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Script : ShowInteractionText
{
    [SerializeField] Player_Inventory player_Inventory;
    public float doorOpenAngle = -90f;
    public float doorCloseAngle = 0f;
    public float smoothTime = 8f;
    public int keyID;

    private string textoporta;
    private bool isOpen = false;

    public bool inRange;
    private Quaternion targetRotation;

    public enum State
    {
        Open,
        Closed,
    }
    public State state;

    void Start()
    {
        if (keyID == 0)
        {
            state = State.Open;
        }
        else
        {
            state = State.Closed;
        }
        inRange = false;
        targetRotation = transform.rotation;
    }

    void Update()
    {
        switch(state)
        {
            case State.Open:
            {
                textoporta = "(E para Abrir)";
                if (inRange == true)
                {
                    base.Show(textoporta);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        ToggleDoor();
                    }
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothTime * Time.deltaTime);
                }
                break;
            }
            case State.Closed:
            {
                textoporta = "A porta está trancada.";
                if (inRange == true)
                {
                    base.Show(textoporta);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (player_Inventory.itemsID.Contains(keyID))
                        {
                            state = State.Open;
                        }
                    }
                }
                break;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    void ToggleDoor()
    {
        isOpen = !isOpen;
        targetRotation = isOpen ? Quaternion.Euler(0, doorOpenAngle, 0) : Quaternion.Euler(0, doorCloseAngle, 0);
    }
}
