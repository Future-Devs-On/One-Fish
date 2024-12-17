using UnityEngine;

public enum SlotTag { Peixe, None }
[CreateAssetMenu(fileName = "NewItem", menuName = "OneFish/Item")]
public class Item : ScriptableObject
{
    public string itemName; 
    public Sprite icon; 

}
