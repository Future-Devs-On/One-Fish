using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{


    //Variaveis
    public GameObject Tela_Inicial;
    public GameObject Tela_Configs;
    public GameObject Tela_Credits;


    //Carregar menus
    public void PlayGame()
    {
        SceneManager.LoadScene("Map");
    }

    public void Options()
    {
        Tela_Inicial.SetActive(false);
        Tela_Configs.SetActive(true);

    }

    public void Credits()
    {
        Tela_Inicial.SetActive(false);
        Tela_Credits.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    //Voltar
    public void Voltar_Options()
    {
        Tela_Configs.SetActive(false);
        Tela_Inicial.SetActive(true);
    }

    public void Voltar_Credits()
    {
        Tela_Credits.SetActive(false);
        Tela_Inicial.SetActive(true);
    }
}
