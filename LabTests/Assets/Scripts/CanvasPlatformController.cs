using UnityEngine;

public class CanvasPlatformController : MonoBehaviour
{
    [SerializeField] private GameObject[] MobileCommands;
    
    void Start()
    {
#if !UNITY_ANDROID
        foreach (var command in MobileCommands)
        {
            command.SetActive(false);
        }
#endif
    }
}
