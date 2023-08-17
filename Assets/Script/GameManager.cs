using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        FindObjectOfType<AudioManager>().Play("Theme");
    }
    public void OnStartButton()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().StopPlaying("Theme");

    }

    public void OnYesButton()
    {
        Application.Quit();
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void OnButton()
    {
        FindObjectOfType<AudioManager>().Play("button Sound");
    }
}
