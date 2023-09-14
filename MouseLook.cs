using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
   //Setting up the variables and assets 
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        //mouse cursor hidden in game
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        //linking the mouse to Unity system mouse input to the mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //decrease Xrotation based on Mouse Y
        xRotation -= mouseY;
        //setting the limitation of the mouse rotation on x-axis
        xRotation = Mathf.Clamp(xRotation, -80f, 60f);

        //This sets the local rotation of the GameObject to a new rotation specified by the xRotation variable, controlling the tilt of the GameObject around its local X-axis. 
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        //allow players to rotate the "playerbody" game object around its x-asix based on the horizontal input "mouse X"
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
