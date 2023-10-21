using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Options_Manager : MonoBehaviour
{
    public TMP_Dropdown resolutiondropdown;
    public AudioMixer audioMixer;
    Resolution[] resolutions; //array com todas as resoluções
    void Start()
    {
        //colocando as resoluções na unity dentro do array
        resolutions = Screen.resolutions;
        //limpando as opções prévias do dropdown
        resolutiondropdown.ClearOptions();
        //criando lista
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
            resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        //adicionando as strings da lista nas opções do dropdown
        resolutiondropdown.AddOptions(options);
        resolutiondropdown.value = currentResolutionIndex;
        resolutiondropdown.RefreshShownValue();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionindex)
    {
        Resolution resolution = resolutions[resolutionindex]; 
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); 
    }
}
