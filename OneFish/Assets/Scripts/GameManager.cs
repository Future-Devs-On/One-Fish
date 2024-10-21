using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public Transform pauseM;
    public static bool paused;
    public GameObject Inv;

    //Telas
    public GameObject Tela_Options;


    private void Awake()
    {
        Singleton = this;
        pauseM.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseM.gameObject.activeSelf)
            {
                pauseM.gameObject.SetActive(false);
                Time.timeScale = 1;
                paused = false;
                PlayerControl.canFish = true;
            }
            else
            {
                pauseM.gameObject.SetActive(true);
                Time.timeScale = 0;
                paused = true;
                PlayerControl.canFish = false;
            }
        }

    }
    
    public void PauseBtn()
    {
        if (pauseM.gameObject.activeSelf)
        {
            pauseM.gameObject.SetActive(false);
            Time.timeScale = 1;
            paused = false;
            PlayerControl.canFish = true;
        }
        else
        {
            pauseM.gameObject.SetActive(true);
            Time.timeScale = 0;
            paused = true;
            PlayerControl.canFish = false;
        }
    }
    
    public void Options()
    {
        Tela_Options.SetActive(true);
    }

    public void Voltar_Options()
    {
        Tela_Options.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Titulo");
        PauseBtn();
    }
}
