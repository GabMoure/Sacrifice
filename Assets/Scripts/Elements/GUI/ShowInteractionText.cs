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
        container.SetActive(true);
        containertext.text = texto;
    }
    public void Hide()
    {
        container.SetActive(false);
        containertext.text = "";
    }
}
