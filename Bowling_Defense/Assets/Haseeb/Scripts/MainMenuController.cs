using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject MainMenuPanel;
    [SerializeField] GameObject ThemeSelectionPanel;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuPanel.SetActive(true);
        ThemeSelectionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton()
    {
        MainMenuPanel.SetActive(false);
        ThemeSelectionPanel.SetActive(true);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void BackButton()
    {
        ThemeSelectionPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
    public void HCG_Theme()
    {
        SceneManager.LoadScene("HCG_Levels");
    }
    public void Farm_Theme()
    {
        SceneManager.LoadScene("Farm_Levels");
    }
}
