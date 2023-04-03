using UnityEngine;

public class CanvasPlatformController : MonoBehaviour
{
    [SerializeField] private GameObject[] MobileCommands;

    private void Start()
    {
#if !UNITY_ANDROID
        foreach (GameObject command in MobileCommands)
        {
            command.SetActive(false);
        }
#endif
    }
}
