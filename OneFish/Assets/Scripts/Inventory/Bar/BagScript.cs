using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.E) && GameManager.isPaused == false) 
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
    /*public void BagBtnOpen()
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
    }*/
}
