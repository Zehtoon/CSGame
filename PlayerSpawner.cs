using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner instance ;
    public Health healthUI;
    public TextMeshProUGUI scoreUI;
    public CinemachineVirtualCamera VCam;
    
    public Vector3 spawnPositionOffset = Vector3.zero; 
    
    public int gemsCollected = 0;

     void Awake()
     {
          if (instance == null)
          {
               instance = this;
          }
          else if (instance != this)
          {
               Debug.LogWarning("Another instance of PlayerSpawner found! Destroying duplicate.");
               Destroy(gameObject);
          }
     }

    // Start is called before the first frame update
    void Start()
    {
        // Calculate the spawn position based on an offset from the current transform position
        Vector3 finalSpawnPosition = spawnPositionOffset;
        
        // Instantiate at the final spawn position with no rotation
        GameObject player = Instantiate(GameManager.instance.currentCharacter.characterPrefab, finalSpawnPosition, Quaternion.identity);
        


         PlayerLife playerHealth = player.GetComponent<PlayerLife>();
        if (playerHealth != null && healthUI != null) {
            Debug.Log("setting up healthUI");
            playerHealth.SetupHealthUI(healthUI);
        }else if(playerHealth == null ){
            Debug.LogError("Player health is null");
        }else if(healthUI  == null){
            Debug.LogError("healthUI is null");
        }
        //setting the vcam to follow the player
        VCam.m_Follow = player.transform;

        // notify the flying AI to follow the player
        NotifyFlyingAi(player.transform);

       
        
        

    }

    private void NotifyFlyingAi(Transform playerTransform)
    {
        FlyingAI[] eagles = FindObjectsOfType<FlyingAI>();
        foreach(var eagle in eagles){
            eagle.SetTarget(playerTransform);
        }
    }
    public void AddGem(int amount){
        gemsCollected += amount;
        UpdateScoreUI();
    }

    public int GetGemsCollected(){
        return gemsCollected;
    }

    private void UpdateScoreUI(){
        scoreUI.text = gemsCollected.ToString();
    }
}
