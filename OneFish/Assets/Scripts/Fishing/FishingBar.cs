using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBar : MonoBehaviour
{
    [Header("BlueBar Movement")]
    [SerializeField] private GameObject blueBar;
    [SerializeField] private float movSpeed = 2f;

    [Header("BlueBar Path")]
    [SerializeField] private Transform[] pathPoints;
    private int currentPoint;
    private void Start()
    {
        currentPoint = 0;
        blueBar.transform.position = pathPoints[currentPoint].position;
    }

    private void Update()
    {
        MoveBlueBar();
    }

    private void MoveBlueBar()
    {
        blueBar.transform.position = Vector2.MoveTowards(blueBar.transform.position, pathPoints[currentPoint].position, movSpeed * Time.deltaTime);

        if (blueBar.transform.position == pathPoints[currentPoint].position)
        {
            currentPoint += 1;
            if (currentPoint >= pathPoints.Length)
            {
                currentPoint = 0;
            }
        }
    }
}
