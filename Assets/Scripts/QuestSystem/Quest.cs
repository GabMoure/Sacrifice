using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    public string questType;
    public int OrderID;
    public int requiredItemID;
}
