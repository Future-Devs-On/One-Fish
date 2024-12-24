using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingArea : MonoBehaviour
{
    [Header("Fish References")]
    public GameObject FishingAreaPrefab;
    private GameObject areaObject;
    public FishingTextManager fishingText; // Referência ao script FishingTextManager

    [Header("References")]
    private GameObject Player;
    PlayerControl playerControl;
    public GameObject ButtonZ;

    [Header("Lists")]
    public List<Vector2> AreasPositions;
    private List<Area> Areas = new List<Area>();
    public Dictionary<GameObject, int> fishingAttempts = new Dictionary<GameObject, int>();

    [Header("Fishing Settings")]
    public int maxFishingAttemptsPerArea = 5; // Limite de tentativas por área

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); // Identifica o player via script
        playerControl = Player.GetComponent<PlayerControl>(); // Pega o script dentro o player que seja do tipo PlayerControl
        GenerateAreas();
    }

    void GenerateAreas()
    {
        for(int i = 0; i < AreasPositions.Count; i++)
        {
            areaObject = Instantiate(FishingAreaPrefab); // Instancia a area
            areaObject.GetComponent<RectTransform>().anchoredPosition = AreasPositions[i]; // diz qual posição a area deve ser instanciada de acordo com as posiçoes da lista
            Area area = areaObject.GetComponent<Area>(); // Pega o script do tipo Area 

            
            if(area != null)
            {
                Areas.Add(area);
                
            }

            // Configurar identificador único
            FishingAreaId identifier = areaObject.AddComponent<FishingAreaId>();
            identifier.id = i;

            // Usar ID como chave no dicionário
            fishingAttempts[areaObject] = 0;

            Interact interact = areaObject.GetComponent<Interact>(); // Referencia ao script interact dentro do GameObject instanciado da area.
            if (interact != null)
            {
                // Adiciona a função ao evento
                interact.Event.AddListener(() => StartFishing(identifier.id));
            }
        }  
        
    }

    private void StartFishing(int areaId)
    {
        
        foreach (var attempts in fishingAttempts)
        {
            // Verifica se o attempts possui o Id igual ao areaId
            if (attempts.Key.GetComponent<FishingAreaId>().id == areaId)
            {
                // Atribui o valor de attempts para o GameObject
                GameObject area = attempts.Key;

                // Verifica a quantidade de vezes que o minigame aconteceu
                if (fishingAttempts[area] < maxFishingAttemptsPerArea)
                {
                    playerControl.AllowFish(true); 
                    fishingAttempts[area]++;
                    Debug.Log($"Tentativas restantes para {area.name}: {maxFishingAttemptsPerArea - fishingAttempts[area]}");
                }
                else
                {
                    playerControl.AllowFish(false);

                    fishingText.ShowFishingMessage($"Área esgotada!");
                    Debug.Log($"Área {area.name} esgotada para pesca.");
                }

                return;
            }
        }

        Debug.LogError($"A área com ID {areaId} não foi encontrada no dicionário!");
    }
    
}
