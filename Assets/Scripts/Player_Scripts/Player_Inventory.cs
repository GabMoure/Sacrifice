using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Player_Inventory : ScriptableObject
{
    public List<GameObject> inventoryList;
    public int MaxInventory = 5;
}
