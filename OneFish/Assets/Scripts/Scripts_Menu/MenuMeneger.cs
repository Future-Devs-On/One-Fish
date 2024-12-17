using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuMeneger : MonoBehaviour
{
    //Variaveis
    public GameObject Tela_Inicial;
    public GameObject Tela_Options;
    public GameObject Tela_Credits;

    //Ir
    public void PlayGame()
    {
        SceneManager.LoadScene("Map");
    }

    public void Options()
    {
        Tela_Inicial.SetActive(false);
        Tela_Options.SetActive(true);

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
        Tela_Options.SetActive(false);
        Tela_Inicial.SetActive(true);
    }

    public void Voltar_Credits()
    {
        Tela_Credits.SetActive(false);
        Tela_Inicial.SetActive(true);
    }
}
