using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayButton()
    {
        int CurrentSscene = SceneManager.GetActiveScene().buildIndex;
        int NextScene = CurrentSscene + 1;
        SceneManager.LoadScene(NextScene);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
