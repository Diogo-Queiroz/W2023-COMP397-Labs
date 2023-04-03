using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public enum Dificulty
{
    Easy, Normal, Hard, VeryHard
}

public class GameController : MonoBehaviour
{
    [SerializeField] private List<NavMeshSurface> _maze;
    public MazeGenerator mazeGenerator;
    public RobotSpawner robotSpawner;
    [SerializeField] private List<GameObject> _robots;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject[] _environmentObjects;
    public static bool isPaused = false;
    public Dificulty difficulty = Dificulty.Easy;

    private void Awake()
    {
        isPaused = false;
        _pausePanel.SetActive(false);
    }

    private void Start()
    {
        SetupMaze();
        foreach (NavMeshSurface tiles in _maze)
        {
            tiles.BuildNavMesh();
        }
        SpawnRobots();
        //foreach (var environmentObject in _environmentObjects)
        //{
        //    environmentObject.SetActive(true);
        //}
    }

    private void SetupMaze()
    {
        mazeGenerator.GenerateMaze();
    }

    private void SpawnRobots()
    {
        robotSpawner.SpawnRobots(mazeGenerator.activeTiles, difficulty);
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
