using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    [SerializeField] private FakeLoading _fakeLoading;

    public void StartButton_Clicked()
    {
        _fakeLoading.StartFakeLoading();
    }

    public void ChangeToGameScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
