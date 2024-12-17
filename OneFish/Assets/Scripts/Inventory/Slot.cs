using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image icon; // Referência ao componente Image do ícone

    // Método para definir o item no slot
    public void SetItem(Item item)
    {
        if (item != null && item.icon != null)
        {
            icon.sprite = item.icon;    // Define o ícone do item
            icon.enabled = true;        // Ativa o ícone
        }
        else
        {
            ClearSlot();
        }
    }

    // Método para limpar o slot
    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;           // Desativa o ícone
    }
}
