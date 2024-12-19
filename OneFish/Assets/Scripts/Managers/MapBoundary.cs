using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBoundary : MonoBehaviour
{
    public Transform center; // Centro da área circular
    public float radius; // Raio da área circular

    private Transform playerTransform;

    void Start()
    {
        // Busca o transform do jogador
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Calcula a distância do jogador ao centro
        Vector2 direction = playerTransform.position - center.position;
        float distance = direction.magnitude;

        if (distance > radius)
        {
            // Move o jogador de volta para o limite do círculo
            direction = direction.normalized;
            playerTransform.position = (Vector2)center.position + direction * radius;

            Debug.Log("Jogador limitado ao círculo!");
        }
    }

    void OnDrawGizmos()
    {
        if (center != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(center.position, radius);
        }
    }
}
