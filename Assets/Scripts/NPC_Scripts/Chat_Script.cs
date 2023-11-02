using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chat_Script : MonoBehaviour
{
    private SpriteRenderer background;
    private TextMeshPro text;

    private void Awake()
    {
        background = transform.Find("box").GetComponent<SpriteRenderer>();
        text = transform.Find("text").GetComponent<TextMeshPro>();
    }
    private void Start()
    {
        Setup("heey brother");

    }

    private void Setup(string texto)
    {
        text.SetText(texto);
        text.ForceMeshUpdate();
        Vector2 textSize = text.GetRenderedValues(false);
        Vector2 space = new Vector2(0f, 0f);
        background.size = textSize + space;

    }
}
