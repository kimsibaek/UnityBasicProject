using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Slot : MonoBehaviour
{
    private Stack<Item> items;

    public Stack<Item> Items
    {
        get
        {
            return items;
        }

        set
        {
            items = value;
        }
    }

    public UILabel itemAmount;

    public UISprite sprite;

    public UIAtlas defaultAtlas;

    private UIRoot mRoot;

    public string defaultSpriteName;

    public bool IsEmpty
    {
        get
        {
            return items.Count == 0;
        }
    }

    public Item CurrentItem
    {
        get
        {
            try
            {
                return items.Peek();
            }
            catch(Exception e)
            {
                Debug.Log(e);
                return null;
            }
        }
    }

    public bool IsAvailable
    {
        get
        {
            return CurrentItem.itemMaxAmount > items.Count;
        }
    }


    private GameObject clone;

    private bool isDragOk;

    void Start()
    {

        items = new Stack<Item>();

        mRoot = NGUITools.FindInParents<UIRoot>(transform.parent);
    }

    void Update()
    {

    }

    public void AddItem(Item item)
    {
        isDragOk = true;

        items.Push(item);

        if (items.Count > 1)
        {
            itemAmount.text = items.Count.ToString();
        }

        ChangeSprite(item.itemAtlas, item.itemSpriteName);
    }

    public void AddAllItem(Stack<Item> items)
    {
        isDragOk = true;

        this.items = new Stack<Item>(items);

        if (items.Count > 1)
        {
            itemAmount.text = items.Count.ToString();
        }
        else
        {
            itemAmount.text = string.Empty;
        }

        ChangeSprite(CurrentItem.itemAtlas, CurrentItem.itemSpriteName);
    }



    private void ChangeSprite(UIAtlas atlas, string name)
    {
        sprite.atlas = atlas;
        sprite.spriteName = name;
    }


    public void OnDragStart()
    {
        if (!isDragOk) return;

        clone = NGUITools.AddChild(transform.parent.gameObject, gameObject);
        clone.transform.localPosition = transform.localPosition;
        clone.transform.localRotation = transform.localRotation;
        clone.transform.localScale = transform.localScale;
        clone.GetComponent<BoxCollider>().enabled = false;
        clone.transform.SetParent(UIDragDropRoot.root);
    }

    public void OnDrag(Vector2 delta)
    {
        if (!isDragOk) return;

        clone.transform.localPosition += (Vector3)(delta * mRoot.pixelSizeAdjustment);
    }

    void OnDragEnd()
    {
        if (!isDragOk) return;

        NGUITools.Destroy(clone.gameObject);
    }

    void OnDrop(GameObject dropped)
    {
        Slot slot = dropped.GetComponent<Slot>();

        if (slot == null || slot.Items.Count == 0)
            return;

        Stack<Item> tmp = new Stack<Item>(this.Items);

        this.AddAllItem(slot.Items);

        if (tmp.Count == 0)
        {
            slot.ClearSlot();
        }
        else
        {
            slot.AddAllItem(tmp);
        }

    }

    void OnClick()
    {
        if (items.Count < 1)
        {
            return;
        }
        // 소비아이템을 경우
        if (this.CurrentItem.itemType == ItemType.Consumable)
        {
            // 아이템 사용
            Debug.Log(this.Items.Pop().itemDesc);

            // 수량 조절
            if (items.Count > 1)
            {
                itemAmount.text = items.Count.ToString();
            }
            else
            {
                itemAmount.text = string.Empty;
            }

            if (items.Count == 0)
            {
                ChangeSprite(defaultAtlas, defaultSpriteName);
            }
        }
    }


    public void ClearSlot()
    {
        isDragOk = false;

        items.Clear();
        ChangeSprite(defaultAtlas, defaultSpriteName);
        itemAmount.text = string.Empty;
    }
}
