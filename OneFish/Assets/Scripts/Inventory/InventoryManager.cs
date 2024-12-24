using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    [Header("References")]
    public GameObject slotPrefab;       // Prefab do slot
    public Transform inventoryPanel;    // Painel onde os slots serão gerados
    public FishingTextManager fishingText; // Referência ao script FishingTextManager

    [Header("Lists")]
    public List<Vector2> slotPositions;    // Lista de posições específicas para os slots
    public List<Item> itemsToInstantiate = new List<Item>(); // Lista de itens disponíveis
    private List<Slot> slots = new List<Slot>();

    void Start()
    {
        GenerateSlots(); 
    }

    // Método para gerar slots nas posições específicas
    void GenerateSlots()
    {
        if (slotPositions.Count == 0)
        {
            Debug.LogError("Nenhuma posição definida para os slots!");
            return;
        }
        for (int i = 0; i < slotPositions.Count; i++)
        {
            GameObject slotObject = Instantiate(slotPrefab, inventoryPanel); // Instancia o slot
            slotObject.GetComponent<RectTransform>().anchoredPosition = slotPositions[i]; // Obtém o componente Slot
            Slot slot = slotObject.GetComponent<Slot>();
            if (slot != null)
            {
                slots.Add(slot); // Adiciona o slot à lista
            }
            else
            {
                Debug.LogError("O prefab do slot não possui o componente Slot!");
            }
        }
    }

    // Método para instanciar um item aleatório no próximo slot disponível
    public void AddRandomItemToInventory()
    {
        
        if (itemsToInstantiate.Count == 0) return;
        

        Item randomItem = GetRandomItem();
        foreach (Slot slot in slots)
        {
            if (slot.icon.sprite == null) // Verifica se o slot está vazio
            {
                slot.SetItem(randomItem); // Define o item no slot
                Debug.Log($"Item {randomItem.itemName} adicionado ao inventário.");
                fishingText.ShowFishingMessage($"você pescou {randomItem.itemName}!");
                return;
            }
        }
        fishingText.ShowFishingMessage($"Inventário cheio!");
        Debug.Log("Inventário cheio!");
        
    }

    // Método para obter um item aleatório da lista
    private Item GetRandomItem()
    {
        int randomIndex = Random.Range(0, itemsToInstantiate.Count);
        return itemsToInstantiate[randomIndex];
    }
}
