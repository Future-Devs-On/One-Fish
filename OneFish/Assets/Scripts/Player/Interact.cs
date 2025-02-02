using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interact : MonoBehaviour
{
    bool Can;
    public static bool isInteract;
    public UnityEvent Event;
    public GameObject Player;
    public GameObject ButtonZ;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
        
    }
    
    void Update()
    {
        interact();
        OnEvent();
    }

    void OnEvent()
    {
        if(Can && isInteract)
        {
            Event.Invoke();
        }
    }

    void interact()
    {
        
        if (Input.GetButtonDown("Interage"))
        {
            isInteract = true;
        }
        else
        {
            isInteract = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player)
        {
            Can = true;
        }

        ButtonZ.gameObject.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            Can = false;
        }

        ButtonZ.gameObject.SetActive(false);
    }
}
