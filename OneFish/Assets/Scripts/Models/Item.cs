using UnityEngine;

public enum SlotTag { Peixe, None, Hand }
[CreateAssetMenu(menuName = "OneFish/Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public SlotTag itemTag;

}
