using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingManager : MonoBehaviour
{
    
    [Header("References")]
    public InventoryManager inventoryManager;
    [SerializeField] private GameObject fishingBar;
    public FishingTextManager fishingText; // Referência ao script FishingTextManager
    


    [Header("Fishs cronometer")]
    [SerializeField] private float maxTimeBetweenFish = 3f;
    private float currentTimeBetweenFish;


    [Header("Fish in rod cronometer")]
    [SerializeField] private float maxTimeForFishing = 5f;
    private float currentTimeForFishing;
    private bool fishInRod;
    


    private void Start()
    {
        FishingReset();
        
    }

    
    public void Update()
    {
        
        if(PlayerControl.canFish)
        {    
            if (!fishInRod)
            {
                RunFishCronometer();
                
            }
            else
            {
                RunFishingCronometer();
            }
        }

    }

    private void RunFishCronometer()
    {
        currentTimeBetweenFish -= Time.deltaTime;
        if (currentTimeBetweenFish <= 0)
        {
            fishInRod = true;
        }
    }

    private void RunFishingCronometer()
    {
        
        currentTimeForFishing -= Time.deltaTime;
        if (currentTimeForFishing > 0)
        {
            fishingBar.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (FishingBarMeter.Instance.isOnGreen)
                {
                    inventoryManager.AddRandomItemToInventory();
                    
                }
                else
                {
                    fishingText.ShowFishingMessage($"O peixe fugiu!");
                }
                
                PlayerControl.canFish = false;
                FishingReset();
            }
        }
        else
        {
            fishingText.ShowFishingMessage($"Acabou o tempo!");

            FishingReset();
        }
    }

    private void FishingReset()
    {
        
        fishInRod = false;
        currentTimeBetweenFish = maxTimeBetweenFish;
        currentTimeForFishing = maxTimeForFishing;
        
        fishingBar.SetActive(false);
        
    }

}
