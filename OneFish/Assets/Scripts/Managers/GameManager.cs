using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static bool isPaused { get; private set; }
    //public static bool paused;
    public static event Action<bool> OnPauseStateChanged;

    [Header("References")]
    public Transform pauseMenu;
    public GameObject Inv;
    public Slider slider;

    //Telas
    public GameObject Tela_Options;


    private void Awake()
    {
       
        gm = this;
        pauseMenu.gameObject.SetActive(false);
        if(MusicManager.instance != null)
        {
            slider.onValueChanged.AddListener(value => MusicManager.instance.ChangeVolume(value));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        OnPauseStateChanged?.Invoke(isPaused);
        if(isPaused)
        {
            pauseMenu.gameObject.SetActive(true);
            Player.canFish = false;
        }
        else{
            pauseMenu.gameObject.SetActive(false);
            Player.canFish = true;
        }
    }
    
    // public void ConfigControl()
    // {
    //     if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         if (pauseMenu.gameObject.activeSelf)
    //         {
    //             pauseMenu.gameObject.SetActive(false);
    //             Time.timeScale = 1;
    //             paused = false;
    //             Player.canFish = true;
    //         }
    //         else
    //         {
    //             pauseMenu.gameObject.SetActive(true);
    //             Time.timeScale = 0;
    //             paused = true;
    //             Player.canFish = false;
    //         }
    //     }
    // }

    
    public void Continue()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        
    }
    public void Options()
    {
        Tela_Options.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        
    }

    public void Voltar_Options()
    {
        Tela_Options.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartScreen");
        Time.timeScale = 1;
    }
}
