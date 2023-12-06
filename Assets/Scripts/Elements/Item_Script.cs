using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Script : MonoBehaviour
{
    [SerializeField] Item item;
    public string itemname;
    public int id;
    public string texto;
    void OnEnable()
    {
        name = item.itemname;
        id = item.id;
        texto = item.text;
    }
}
