using UnityEngine;

[CreateAssetMenu(fileName="Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string name;
    public string description;

    public Sprite image;


    public int hpBonus;
    public int SpeedBonus;
    public float duration;

}
