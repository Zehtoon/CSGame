using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    
    public int sceneBuildIndex;
    public Animator animator;
    private AudioManager audioManager;
    public GameObject Star;

    private void Awake()
    {
        audioManager = ServiceLocator.Get<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player" && !Star.activeSelf){
            audioManager.PlaySFX(audioManager.Win);
            StartCoroutine(LevelLoader(SceneManager.GetActiveScene().buildIndex + 1));


            Debug.Log("should switch scenes");
            print("switching Scene to: " + sceneBuildIndex);
            // SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            
        }
    }
    
    IEnumerator LevelLoader(int index)
    {
        UnlockNewLevel();
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadSceneAsync(index);
        // if(index + 1 > PlayerPrefs.GetInt("levelAt")){
        //     PlayerPrefs.SetInt("levelAt",index);
        // }
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();

        }
    }
}
