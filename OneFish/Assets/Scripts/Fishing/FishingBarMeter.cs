using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBarMeter : MonoBehaviour
{
    public static FishingBarMeter Instance;
    public bool isOnGreen { get; private set; } = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    
        if(other.gameObject.GetComponent<FishingBarAllowedArea>() != null)
        {
            isOnGreen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<FishingBarAllowedArea>() != null)
        {
            isOnGreen = false;
        }
    }

}
