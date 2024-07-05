using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemCollector : MonoBehaviour
{
    private AudioManager audioManager;

//     public TextMeshProUGUI scoreUI;
     void Awake()
     {
        audioManager = ServiceLocator.Get<AudioManager>();
     }



    void Update()
   {
     //    scoreUI.text =  gemsCollected.ToString(); 
   }

     private void OnTriggerEnter2D(Collider2D collision)
     {
          if (collision.gameObject.CompareTag("Gem"))
          {
               audioManager.PlaySFX(audioManager.GemCollected);
               Destroy(collision.gameObject);
        
               if (PlayerSpawner.instance != null)
               {
                    PlayerSpawner.instance.AddGem(1);
               }
               else
               {
                    Debug.LogWarning("PlayerSpawner instance not found.");
               }
          }
          
     }


   
}




