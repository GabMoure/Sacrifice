using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    int zoom = 20;
    int normal = 60;
    float smooth = 5.0f; 
    [SerializeField] PlayerMovement playerMovement;
    void Update()
    {
        if (playerMovement.door_interaction.fresta == true)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, smooth * Time.deltaTime);
        }
        else
        {
            GetComponent<Camera>().fieldOfView= Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, smooth * Time.deltaTime);
        }
    }
}
