using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tileDisappear : MonoBehaviour
{
    public float disappearanceDelay = 0.25f; // Delay before the object disappears
    private bool isPlayerColliding = false; // Flag to track player collision
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            // Set the flag to true to indicate player collision
            isPlayerColliding = true;

            // Start a coroutine to delay the disappearance
            StartCoroutine(DisappearAfterDelay());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            // Reset the flag when the player exits the trigger
            isPlayerColliding = false;
        }
    }

    private IEnumerator DisappearAfterDelay()
    {
        animator.SetTrigger("Disappear");
        // Wait for the specified delay before disappearing
        yield return new WaitForSeconds(disappearanceDelay);

        // Check if the player is still colliding with the object
        if (isPlayerColliding)
        {
            // Perform the disappearance logic
            // gameObject.SetActive(false); // Or any other method to make the object disappear
            Destroy(gameObject);
        }
    }
}
