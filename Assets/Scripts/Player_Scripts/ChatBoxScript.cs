using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChatBoxScript : MonoBehaviour
{
    [SerializeField] TextMeshPro chattext;
    private void Chat(string texto)
    {
        chattext.text = texto;
    }
}
