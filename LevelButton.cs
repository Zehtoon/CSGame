using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{

    public string levelID;
    private Button button;
    

    private void Awake()
    {
        button = GetComponent<Button>();
        button.interactable = LevelManager.IsLevelUnclocked(levelID);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelID);
    }
}
