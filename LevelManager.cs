using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static void UnlockLevel(string levelID)
    {
        int unlockedLevelID = int.Parse(PlayerPrefs.GetString("highestLevelUnlocked", "1"));
        int thisLevelId = int.Parse(levelID);

        if (thisLevelId > unlockedLevelID)
        {
            PlayerPrefs.SetString("highestLevelUnlocked",levelID);
            PlayerPrefs.Save();
        }
    }


    public static bool IsLevelUnclocked(string levelID)
    {
        int unlockedLevelID = int.Parse(PlayerPrefs.GetString("highestLevel", "1"));
        int thisLevelID = int.Parse(levelID);

        return thisLevelID <= unlockedLevelID;
    }
}
