using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject[] mobileControllers;
    
    private void Start()
    {
#if !UNITY_ANDROID
        foreach (var mobileController in mobileControllers)
        {
            mobileController.SetActive(false);
        }
#endif
    }
}
