using UnityEngine;
using System.Collections;

public enum ItemType
{
    Weapon,
    Armor,
    Hand,
    Head,
    Consumable,
    Ring
};

[System.Serializable]
public class Item
{
    public string itemName;
    public int itemID;
    public string itemDesc;
 
    public int itemPower;
    public int itemSpeed;
    public int itemHealAmount;
    public int itemManaAmount;
    public int itemMaxAmount;
    public ItemType itemType;

    public UIAtlas itemAtlas;
    public string itemSpriteName;
}
