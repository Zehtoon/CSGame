using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] Slider slider;

    [Header("----------Audio Source----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    

    [Header("----------Audio Clip----------")]
    public AudioClip background;
    public AudioClip Death;
    public AudioClip Attack; 
    public AudioClip Hurt;
    public AudioClip Win;
    public AudioClip Click;
    public AudioClip Wrong;
    public AudioClip Right;
    public AudioClip GameOver;
    public AudioClip GemCollected;
    public AudioClip Healing;
    public AudioClip jumpBounce;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Ensures only one AudioManager exists
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Keeps AudioManager alive between scenes

        ServiceLocator.Register<AudioManager>(instance);
    }
    private void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else{
            Load();
        }
        Debug.LogWarning("Playing music");
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void ChangeVolume()
    {
        musicSource.volume = slider.value;
        SFXSource.volume = slider.value;
        Save();
    }

    private void Load()
    {
        slider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", slider.value);
    }
}
