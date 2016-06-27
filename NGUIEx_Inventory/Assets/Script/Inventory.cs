using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public GameObject slotPrefabs;

    public List<Slot> MySlots;

    public int emptySlots;

	void Start ()
    {
        MySlots = new List<Slot>();

        emptySlots = 25;

        for (int i = 0; i < 25; i++)
        {
            GameObject slot = NGUITools.AddChild(gameObject, slotPrefabs);
            MySlots.Add(slot.GetComponent<Slot>());
        }
	}

    public bool AddItem(Item item, int amount)
    {
        if (item.itemMaxAmount == 1)
        {
            PlaceEmpty(item, 1);
            return true;
        }
        else
        {
            for (int i = 0; i < MySlots.Count; i++)
            {
                Slot tmp = MySlots[i];
                if (!tmp.IsEmpty)
                {
                    if (tmp.CurrentItem.itemID == item.itemID && tmp.IsAvailable)
                    {
                        for (int j = 0; j < amount && tmp.IsAvailable; j++)
                        {
                            tmp.AddItem(item);
                        }
                        return true;
                    }
                }
            }

            // 슬롯에 맛는 아이템이 없는경우
            if(emptySlots > 0)
            {
                PlaceEmpty(item, amount);
                return true;
            }
        
        }
        return false;
    }

    private bool PlaceEmpty(Item item, int amount)
    {
        if (emptySlots > 0)
        {
            for (int i = 0; i < MySlots.Count; i++)
            {            
                Slot tmp = MySlots[i];

                if (tmp.IsEmpty)
                {
                    tmp.AddItem(item);

                    for (int j = 0; j < amount-1 && tmp.IsAvailable; j++)
                    {
                        tmp.AddItem(item);
                        
                    }
                    emptySlots--;
                    return true;
                }
            }
        }
        return false;
    }

}
