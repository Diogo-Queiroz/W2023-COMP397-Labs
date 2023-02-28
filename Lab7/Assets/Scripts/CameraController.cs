using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 10.0f;
    public Transform playerBody;
    private float XRotation = 0.0f;
    
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameController.isPaused) { return; }

        float x = Input.GetAxis("Mouse X") * mouseSensitivity;
        float y = Input.GetAxis("Mouse Y") * mouseSensitivity;

        XRotation -= y;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);
        playerBody.Rotate(Vector3.up * x);
    }
}
