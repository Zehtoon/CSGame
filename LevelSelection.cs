using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;

    // Start is called before the first frame update
    void Start()
    {
        int unclockedLevels = PlayerPrefs.GetInt("UnlockedLevel", 1); 
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            lvlButtons[i].interactable = false;
        }
        for (int i = 0; i< unclockedLevels; i++)
        {
            lvlButtons[i].interactable = true;
        }

        
    }

}

