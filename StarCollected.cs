using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollected : MonoBehaviour
{
   private AudioManager audioManager;

    private void Awake()
    {
        audioManager = ServiceLocator.Get<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect();
        }
    }

    void Collect()
    {
        audioManager.PlaySFX(audioManager.GemCollected);
        gameObject.SetActive(false); // Deactivate the star object
    }
}
