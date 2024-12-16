using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingManager : MonoBehaviour
{
    [Header("References")]
    Inventory inventory;
    [SerializeField] private GameObject fishingBar;

    [Header("Fishs cronometer")]
    [SerializeField] private float maxTimeBetweenFish = 3f;
    private float currentTimeBetweenFish;

    [Header("Fish in rod cronometer")]
    [SerializeField] private float maxTimeForFishing = 5f;
    private float currentTimeForFishing;
    private bool fishInRod = false;

    public GameObject Inv;

    private void Start()
    {
        FishingReset();
    }

    
    private void Update()
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
        if(currentTimeForFishing > 0)
        {
            fishingBar.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (FishingBarMeter.Instance.isOnGreen)
                {
                    Inv.gameObject.SetActive(true);
                    inventory.SpawnItem();
                    Debug.Log("Pescou");
                    Inv.gameObject.SetActive(false);
                    ButtonBar.anime.SetBool("isOpen", false);
                }
                else
                {

                    Debug.Log("O peixe fugiu");
                }

                FishingReset();
            }
        }
        else
        {
            Debug.Log("acabou o tempo");

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
