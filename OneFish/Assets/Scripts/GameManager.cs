using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public Transform pauseM;
    public static bool paused;
    public GameObject Inv;
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
    

}
