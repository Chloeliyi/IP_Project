using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject MainMenu;

    public GameObject OptionsMenu;

    public GameObject HowToPlayMenu;

    public GameObject QuitMenu;

    public GameObject PauseMenu;

    public GameObject CreditsMenu;

    private void Start()
    {
        QuitMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        HowToPlayMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void OnStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnOptionButton()
    {
        //MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void OnHowToPlayButton()
    {
        //MainMenu.SetActive(false);
        HowToPlayMenu.SetActive(true);
    }

    public void OnCreditsButton()
    {
        //MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void OnQuitButton()
    {
        QuitMenu.SetActive(true);
    }

    public void OnYesButton()
    {
        Application.Quit();
    }

    public void OnNoButton()
    {
        QuitMenu.SetActive(false);
    }

    public void OnBackButton()
    {
        HowToPlayMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        //MainMenu.SetActive(true);
    }
}
