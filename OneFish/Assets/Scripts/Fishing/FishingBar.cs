using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBar : MonoBehaviour
{
    [Header("Bars Movement")]
    [SerializeField] private GameObject blueBar;
    [SerializeField] private GameObject greenBar;
    [SerializeField] private float blueMovSpeed = 2f;
    [SerializeField] private float greenMovSpeed = 2f;

    [Header("Bars Path")]
    [SerializeField] private Transform[] pathPoints;
    private int currentGreenPoint;
    private int currentBluePoint;

    private void Start()
    {
        currentBluePoint = 0;
        currentGreenPoint = 0;
        blueBar.transform.position = pathPoints[currentBluePoint].position;
        greenBar.transform.position = pathPoints[currentGreenPoint].position;
    }

    private void Update()
    {
        MoveBlueBar();
        MoveGreenBar();
    }

    private void MoveBlueBar()
    {
        blueBar.transform.position = Vector2.MoveTowards(blueBar.transform.position, pathPoints[currentBluePoint].position, blueMovSpeed * Time.deltaTime);

        if (blueBar.transform.position == pathPoints[currentBluePoint].position)
        {
            currentBluePoint += 1;
            if (currentBluePoint >= pathPoints.Length)
            {
                currentBluePoint = 0;
            }
        }
    }

    private void MoveGreenBar()
    {
        greenBar.transform.position = Vector2.MoveTowards(greenBar.transform.position, pathPoints[currentGreenPoint].position, greenMovSpeed * Time.deltaTime);

        if (greenBar.transform.position == pathPoints[currentGreenPoint].position)
        {
            currentGreenPoint += 1;
            if (currentGreenPoint >= pathPoints.Length)
            {
                currentGreenPoint = 0;
            }
        }
    }
}
