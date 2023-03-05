using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<NavMeshSurface> _maze;
    [SerializeField] private List<GameObject> _robots;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject[] _environmentObjects;
    public static bool isPaused = false;

    private void Awake()
    {
        isPaused = false;
        _pausePanel.SetActive(false);
    }

    private void Start()
    {
        foreach (var tiles in _maze)
        {
            tiles.BuildNavMesh();
        }
        foreach (var robot in _robots)
        {
            robot.SetActive(true);
        }

        foreach (var environmentObject in _environmentObjects)
        {
            environmentObject.SetActive(true);
        }
    }

    private void Update()
    {
#if !UNITY_ANDROID
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
#endif
    }

    private void Pause()
    {
        isPaused = !isPaused;
        _pausePanel.SetActive(isPaused);
        PauseGame(isPaused);
    }

    private void PauseGame(bool isPausing)
    {
#if !UNITY_ANDROID
        Cursor.lockState = isPausing ? CursorLockMode.None : CursorLockMode.Locked;
#endif
        Time.timeScale = isPausing ? 0 : 1;
    }

    public void MainMenuButton_Pressed()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }

    public void PauseButton_Pressed()
    {
        Pause();
    }
}
