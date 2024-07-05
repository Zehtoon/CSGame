using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public string tutorialkey;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            // TutorialManager.Instance.ShowTutorial(tutorialkey);
        }
    }
    
}
