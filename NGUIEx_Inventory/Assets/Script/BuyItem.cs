using UnityEngine;
using System.Collections;

public class BuyItem : MonoBehaviour
{
    public int amount;

    public Inventory inventory;

    public ItemDatabase itemdatabase;


    public void buyHeal()
    {
        inventory.AddItem(itemdatabase.Database[0], amount);
    }

    public void buyMana()
    {
        inventory.AddItem(itemdatabase.Database[1], amount);
    }
}
