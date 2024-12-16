using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public static Inventory Singleton;
    public Item[] slots;
    public Image[] slotImage;

    void Start()
    {
        
    }

    void Update()
    {

    }
    public void SpawnItem()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i] != null)
            {
                slotImage[i].sprite = slots[i].itemSprite;
                break;
            }
        }
    }

}
