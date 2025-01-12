using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FishingArea : MonoBehaviour
{
    [Header("Fish References")]
    public GameObject FishingAreaPrefab;
    private GameObject areaObject;
    public Tile fishAreaTile;
    public FishingTextManager fishingText; // Referência ao script FishingTextManager

    [Header("References")]
    private GameObject Player;
    Player playerScript;
    public GameObject ButtonZ;

    [Header("Lists")]
    public List<Vector2> AreasPositions;
    private List<Area> Areas = new List<Area>();
    public Dictionary<Vector2, int> fishingAttempts = new Dictionary<Vector2, int>();

    [Header("Settings")]
    private List<Vector3Int> tilePositions;
    public Tilemap tilemap;
    public int maxFishingAttemptsPerArea = 5; // Limite de tentativas por área

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); // Identifica o player via script
        playerScript = Player.GetComponent<Player>(); // Pega o script dentro o player que seja do tipo Player
        GenerateAreas();
    }

    void GenerateAreas()
    {
        tilePositions = new List<Vector3Int>(); // Inicializa a lista de Vector3Int

        for (int i = 0; i < AreasPositions.Count; i++)
        {
            Vector2 areaPosition = AreasPositions[i];

            // Converte Vector2 para Vector3Int e adiciona à lista
            Vector3Int tilePosition = new Vector3Int(
                Mathf.RoundToInt(areaPosition.x),
                Mathf.RoundToInt(areaPosition.y),
                0 // Z pode ser fixo ou outro valor, dependendo da sua lógica
            );
            tilePositions.Add(tilePosition);

            // Define o tile no Tilemap
            tilemap.SetTile(tilePosition, fishAreaTile);

            // Instancia a área de pesca
            areaObject = Instantiate(FishingAreaPrefab);
            areaObject.GetComponent<RectTransform>().anchoredPosition = areaPosition; // diz qual posição a area deve ser instanciada de acordo com as posiçoes da lista

            // Configura o script da área
            Area area = areaObject.GetComponent<Area>();
            if (area != null)
            {
                Areas.Add(area);

            }

            
            fishingAttempts[areaPosition] = 0;


            Interact interact = areaObject.GetComponent<Interact>(); // Referencia ao script interact dentro do GameObject instanciado da area.
            if (interact != null)
            {
                // Adiciona a função ao evento
                Vector2 capturedPosition = areaPosition;
                interact.Event.AddListener(() => StartFishing(capturedPosition));
            }
        }

    }

    private void StartFishing(Vector2 areaPosition)
    {
        if (fishingAttempts.TryGetValue(areaPosition, out int currentAttempts))
        {
            // Verifica a quantidade de vezes que o minigame aconteceu
            if (currentAttempts < maxFishingAttemptsPerArea)
            {
                playerScript.AllowFish(true);
                fishingAttempts[areaPosition]++;
                Debug.Log($"Tentativas restantes para posição {areaPosition}: {maxFishingAttemptsPerArea - fishingAttempts[areaPosition]}");
            }
            else
            {
                playerScript.AllowFish(false);
                fishingText.ShowFishingMessage($"Área esgotada!");
                Debug.Log($"Área na posição {areaPosition} esgotada para pesca.");
            }
        }
        else
        {
            Debug.LogError($"A posição {areaPosition} não foi encontrada no dicionário!");
        }
        
    }
}
