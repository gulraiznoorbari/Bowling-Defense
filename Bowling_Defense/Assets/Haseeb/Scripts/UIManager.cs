using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LosePanel;
    [SerializeField] bool IsWin;
    [SerializeField] bool IsLose;
    public bool Win() => IsWin;
    public bool lose() => IsLose;
    private BallSpawner ballSpawner;
    private Ball ball;
    void Start()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
        ballSpawner = FindObjectOfType<BallSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball == null)
        {
            ball = FindObjectOfType<Ball>();
        }
        GameWin();
        GameLose();
    }

    void GameWin()
    {
        int totalball = ballSpawner.TotalBall();
        int currentball = ballSpawner.CurrentBall();
        Debug.Log($"Total Ball {totalball}");
        Debug.Log($"Current Ball {currentball}");
        if (currentball == totalball)
        {
            IsWin = true;
            if (!IsLose)
            {
                WinPanel.SetActive(true);
            }
        }
    }
    void GameLose()
    {
        bool gamelose = ball.GameLose();
        if (gamelose == true)
        {
            IsLose = true;
            if (!IsWin)
            {
                LosePanel.SetActive(true);
            }
        }
    }
    public void RestartButton()
    {
        int CurrentSscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSscene);
    }
    public void NextLevelButton()
    {
        int CurrentSscene = SceneManager.GetActiveScene().buildIndex;
        int NextScene = CurrentSscene + 1;
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