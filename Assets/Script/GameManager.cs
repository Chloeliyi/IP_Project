using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MainMenu;

    public GameObject MusicMenu;

    public GameObject InstructionsMenu;

    public GameObject QuitMenu;

    public GameObject PauseMenu;

    private void Start()
    {
        QuitMenu.SetActive(false);
        MusicMenu.SetActive(false);
        InstructionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void OnStartButton()
    {

    }

    public void OnMusicButton()
    {
        MainMenu.SetActive(false);
        MusicMenu.SetActive(true);
    }

    public void OnInstructionsButton()
    {
        MainMenu.SetActive(false);
        InstructionsMenu.SetActive(true);
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
        InstructionsMenu.SetActive(false);
        MusicMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
