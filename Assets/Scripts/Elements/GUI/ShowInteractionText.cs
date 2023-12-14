using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowInteractionText : MonoBehaviour
{
    public GameObject container;
    public TextMeshProUGUI containertext;
    public void Show(string texto)
    {
        containertext.text = texto;
        container.SetActive(true);
    }
    public void Hide()
    {
        containertext.text = "";
        container.SetActive(false);
    }
}
