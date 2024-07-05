using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    private bool isLoading = false;
    public int SceneIndex;
    public Animator animator;
    AudioManager audioManager;
    public GameObject ScoreBoard;
    public GameObject TutoBoard;
    public GameObject SettingsBoard;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (!PlayerPrefs.HasKey("TutoBoard"))
    {
        // If not shown before, show the pop-up panel
        TutoBoard.SetActive(true);
    }
    }
    public void StartGame()
    {
        if(!isLoading)
        {
            audioManager.PlaySFX(audioManager.Click);
            isLoading = true;
            StartCoroutine(LevelLoader(SceneIndex));
        }
        
    }
    public void ShowBoard()
    {
        audioManager.PlaySFX(audioManager.Click);
        ScoreBoard.SetActive(true);

    }
    public void HideBoard()
    {
        ScoreBoard.SetActive(false);
    }
    public void ShowSettings()
    {
        SettingsBoard.SetActive(true);

    }
    public void HideSettings()
    {
        SettingsBoard.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator LevelLoader(int index)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadSceneAsync(index);
    }

    void HideTutorial(GameObject imagePanel)
    {
        imagePanel.SetActive(false);
    }
    public void ShowTutorial()
    {
        TutoBoard.SetActive(true);
    }
    void HideTutorial()
    {
        TutoBoard.SetActive(false);
    }


    public void ToggleCurrentPanel()
    {
        PlayerPrefs.SetInt("TutoBoard", 1);
        HideTutorial(TutoBoard); 
    }
}
