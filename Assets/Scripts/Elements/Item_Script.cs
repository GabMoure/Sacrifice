using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Script : MonoBehaviour
{
    [SerializeField] Item item;
    string itemname;
    int id;
    void OnEnable()
    {
        name = item.itemname;
        id = item.id;
    }
}
