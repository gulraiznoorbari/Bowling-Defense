using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LosePanel;
    [SerializeField] GameObject _confettis;
    [SerializeField] bool IsWin;
    [SerializeField] bool IsLose;
    public bool Win() => IsWin;
    public bool lose() => IsLose;
    private BallSpawner ballSpawner;
    [SerializeField] Pins[] PinsHolder;
    [SerializeField] public List<Pins> pins = new List<Pins>();
    
    private void Awake()
    {
        PinsHolder = FindObjectsOfType<Pins>();
    }

    private void Start()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
        ballSpawner = FindObjectOfType<BallSpawner>();
        foreach (Pins pin in PinsHolder)
        {
            pins.Add(pin.GetComponent<Pins>());
        }
    }

    private void Update()
    {
        GameWin();
        GameLose();
    }

    public void GameWin()
    {
        int totalball = ballSpawner.TotalBall();
        int currentball = ballSpawner.CurrentBall();
        if (currentball == totalball && pins.Count > 0 && IsWin == false)
        {
            IsWin = true;
            if (IsWin && !IsLose)
            {
                WinPanel.SetActive(true);
                _confettis.SetActive(true);
            }
        }
    }

    public void GameLose()
    {
        if (pins.Count == 0)
        {
            IsLose = true;
            if (IsLose && !IsWin)
            {
                LosePanel.SetActive(true);
            }
        }
    }

    public void RestartButton()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene);
    }
    
    public void NextLevelButton()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        int NextScene = CurrentScene + 1;
        int LastScene = SceneManager.sceneCountInBuildSettings;
        if (NextScene == LastScene)
        {
            NextScene = 0;
        }
        SceneManager.LoadSceneAsync(NextScene);
    }
    
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
