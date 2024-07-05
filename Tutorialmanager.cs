using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] public GameObject imagePanel1;
    [SerializeField] public GameObject imagePanel2;
    [SerializeField] public GameObject imagePanel3;
    private int currentPanel = 0;

    void Start()
    {
        ShowTutorial(imagePanel1);
        currentPanel = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ToggleCurrentPanel();
        }
    }

    void ShowTutorial(GameObject imagePanel)
    {
        imagePanel.SetActive(true);
    }

    void HideTutorial(GameObject imagePanel)
    {
        imagePanel.SetActive(false);
    }

    void ToggleCurrentPanel()
    {
        switch (currentPanel)
        {
            case 1:
                HideTutorial(imagePanel1);
                ShowTutorial(imagePanel2);
                currentPanel = 2;
                break;
            case 2:
                HideTutorial(imagePanel2);
                ShowTutorial(imagePanel3);
                currentPanel = 3;
                break;
            case 3:
                HideTutorial(imagePanel3);
                currentPanel = 0;
                break;
            case 0:
                ShowTutorial(imagePanel1);
                currentPanel = 1;
                break;
        }
    }
}
