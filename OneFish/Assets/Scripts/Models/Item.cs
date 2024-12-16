using UnityEngine;

public enum SlotTag { Peixe, None }
[CreateAssetMenu(menuName = "OneFish/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public SlotTag itemTag;

}
