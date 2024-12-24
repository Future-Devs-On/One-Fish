using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingTextManager : MonoBehaviour
{
    public GameObject floatingTextPrefab; // Prefab do texto flutuante
    public Transform textParent; // Área onde o texto será exibido na tela 

    public void ShowFishingMessage(string message)
    {
        GameObject newText = Instantiate(floatingTextPrefab, textParent);
        FloatingText floatingText = newText.GetComponent<FloatingText>();
        floatingText.ShowMessage(message);
    }
}
