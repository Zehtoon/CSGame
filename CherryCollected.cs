using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryCollected : MonoBehaviour
{
    public int healthBoost = 10;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){
            audioManager.PlaySFX(audioManager.Healing);
            PlayerLife playerLife = collider.gameObject.GetComponent<PlayerLife>();
            if(playerLife != null ){
                playerLife.GainHealth(healthBoost);
                Destroy(gameObject);
            }
        }
    }
}
