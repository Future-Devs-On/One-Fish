using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{

    public static MusicManager instance;

    //Music
    private bool Som = true;
    public AudioSource backMusic;
    public AudioClip startScreenMusic;
    public AudioClip mapMusic;

    //Sprite Button
    public Sprite spriteOnSond;
    public Sprite spriteOffSond;
    public Image muteImage;

    //slider
    public Slider volumeSlier;

    public void OnOffSond()
    {
        Som = !Som;
        backMusic.enabled = Som;

        if (Som)
        {
            muteImage.sprite = spriteOnSond;
        }
        else
        {
            muteImage.sprite = spriteOffSond;
        }
    }

    //Slide
    public void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume(float v)
    {
        AudioListener.volume = volumeSlier.value;
        v = volumeSlier.value;
        Save();
    }

    private void Load()
    {
        volumeSlier.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", volumeSlier.value);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SwitchMusic(scene.name);
    }

    //Método para trocar a musica de acordo com a cena
    private void SwitchMusic(string sceneName)
    {
        AudioClip newClip = null;

        switch(sceneName)
        {
            case "StartScreen":
                newClip = startScreenMusic;
                break;

            case "Map":
                newClip = mapMusic;
                break;
            
            default:
                newClip = null;
                break;

        }

        if (newClip != null && backMusic.clip != newClip)
        {
            StartCoroutine(SmoothTransition(newClip));
        }
    }

    //Método pro fade da musica quando trocar de cena
    private IEnumerator SmoothTransition(AudioClip newClip)
    {
        // Fade-out
        while (backMusic.volume > 0)
        {
            backMusic.volume -= Time.deltaTime;
            yield return null;
        }

        // Trocar a música e fazer fade-in
        backMusic.clip = newClip;
        backMusic.Play();

        while (backMusic.volume < 1)
        {
            backMusic.volume += Time.deltaTime;
            yield return null;
        }
    }

}
