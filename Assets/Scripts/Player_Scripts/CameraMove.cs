using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cameraspd;
    public Transform player;
    float xrotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * cameraspd * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * cameraspd * Time.deltaTime;
        ///
        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -90, 90);
        //
        transform.localRotation = Quaternion.Euler(xrotation, 0, 0);
        ///
        player.Rotate(Vector3.up * mouseX);
    }

}
