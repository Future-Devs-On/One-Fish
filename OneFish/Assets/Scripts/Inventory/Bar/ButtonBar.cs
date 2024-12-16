using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBar : MonoBehaviour
{
    public GameObject Inv;
    public static Animator anime;
    
    void Start()
    {
        Inv.SetActive(false);
        
        anime = GetComponent<Animator>();

    }

    void Update()
    {
        Bag();
    }

    public void Bag()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && GameManager.paused == false) 
        {
            if(Inv.gameObject.activeSelf)
            {
                anime.SetBool("isOpen", false);
                Inv.gameObject.SetActive(false);
            }
            else
            {
                anime.SetBool("isOpen", true);
                Inv.gameObject.SetActive(true);
            }

        }

        
    }
    public void BagBtnOpen()
    {
        if (Inv.gameObject.activeSelf)
        {
            anime.SetBool("isOpen", false);
            Inv.gameObject.SetActive(false);
        }
        else
        {
            anime.SetBool("isOpen", true);
            Inv.gameObject.SetActive(true);
        }
    }

    public void BagBtnClosed()
    {
        
        anime.SetBool("isOpen", false);
        Inv.gameObject.SetActive(false);
    }
}
