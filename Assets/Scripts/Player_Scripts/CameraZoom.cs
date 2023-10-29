using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    int zoom = 20;
    int normal = 60;
    float smooth = 5.0f; 
    public DoorScript doorscript;
    void Update()
    {
        if (doorscript.fresta == true)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, smooth * Time.deltaTime);
        }
        else
        {
            GetComponent<Camera>().fieldOfView= Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, smooth * Time.deltaTime);
        }
    }
}
