using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [Header("Controls")] 
    public Joystick joystick;
    public float horizontalSensitivity;
    public float verticalSensitivity;
    
    public float mouseSensitivity = 10.0f;
    public Transform playerBody;
    private float XRotation = 0.0f;

    [Header("Sliders Sensitivity")]
    public Slider horizontalSlider;
    public Slider verticalSlider;

    
    // Start is called before the first frame update
    private void Start()
    {
#if !UNITY_ANDROID
        Cursor.lockState = CursorLockMode.Locked;
#endif
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameController.isPaused) { return; }
#if !UNITY_ANDROID
        float x = Input.GetAxis("Mouse X") * mouseSensitivity;
        float y = Input.GetAxis("Mouse Y") * mouseSensitivity;
#elif UNITY_ANDROID
        float x = joystick.Horizontal * horizontalSensitivity;
        float y = joystick.Vertical * verticalSensitivity;
#endif

        XRotation -= y;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);
        playerBody.Rotate(Vector3.up * x);
    }

    public void OnHorizontalSliderChange()
    {
        horizontalSensitivity = horizontalSlider.value;
    }

    public void OnVerticalSliderChange()
    {
        verticalSensitivity = verticalSlider.value;
    }
}
