using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory : Player_Inventory
{
    public bool isPressed;
    private float rollspeed = 30.0f;
    [SerializeField] GameObject inventoryparent, middleparent, rightparent, leftparent;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isPressed = !isPressed;
        }

        if (isPressed == true)
        {
            inventoryparent.SetActive(true);
            if (Input.GetKeyDown(KeyCode.A))
            {
                middleparent.transform.position = Vector3.MoveTowards(middleparent.transform.position,
                rightparent.transform.position, rollspeed * Time.deltaTime);
            }
        }
    }
}
