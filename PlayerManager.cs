using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject[] playerPrefabs;
    int characterIndex;
    public static Vector2 lastCheckPointPos = new Vector2(-3,0);


    private void Awake(){
        characterIndex = PlayerPrefs.GetInt("selectedCharacter", 0);
        Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
