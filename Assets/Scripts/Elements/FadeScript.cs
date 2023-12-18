using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool fadein = false;
    public bool fadeout = false;
    public float fadeTime;

    public void FadeIn()
    {
        fadein = true;
    }
    
    public void FadeOut()
    {
        fadeout = true;
    }

    void Update()
    {
        if (fadein == true)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += fadeTime * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    fadein = false;
                } 
            }
        }

        if (fadeout == true)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= fadeTime * Time.deltaTime;
                if (canvasGroup.alpha < 0)
                {
                    fadeout = false;
                } 
            }
        }

    }
}
