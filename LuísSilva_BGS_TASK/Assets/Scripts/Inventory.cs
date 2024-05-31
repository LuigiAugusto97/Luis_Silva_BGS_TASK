using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<ItemData> _inventory;
    public List<ItemData> _Inventory
    {
        get { return _inventory; }
    }

    //To remove an item count
    public void DecreaseItemCount(ItemSO item, int count = 1)
    {
        var itemToBeUsed = _inventory.First(invItem => invItem.Item == item);
        itemToBeUsed.ItemCount -= count;
        if (itemToBeUsed.ItemCount == 0)
        {
            _inventory.Remove(itemToBeUsed);
        }
    }

    //To add an Item to the Inventory
    public void AddItem(ItemSO itemToAdd, int count = 1)
    {
        var itemAlreadyinInventory = _inventory.FirstOrDefault(item => item.Item == itemToAdd);
        if (itemAlreadyinInventory != null)
        {
            itemAlreadyinInventory.ItemCount += count;
        }
        else
        {
            _inventory.Add(new ItemData()
            {
                Item = itemToAdd,
                ItemCount = count
            });
        }
    }

    //To check if inventory Contains Item
    public bool CheckIfItemPresent(ItemSO itemToCheck, int count = 1)
    {
        var itemAlreadyinInventory = _inventory.FirstOrDefault(item => item.Item == itemToCheck);
        if (itemAlreadyinInventory != null)
        {
            if (itemAlreadyinInventory.ItemCount >= count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //Get the item count
    public int GetItemCount(ItemSO itemToCount)
    {
        var itemToGetCount = _inventory.FirstOrDefault(item => item.Item == itemToCount);
        if (itemToGetCount != null)
        {
            return itemToGetCount.ItemCount;
        }
        else
        {
            return 0;
        }

    }

    //Always find Players Inventory
    public static Inventory GetInventory()
    {
        return FindObjectOfType<PlayerMovement>().GetComponent<Inventory>();
    }
}

[Serializable]
public class ItemData
{
    [SerializeField] ItemSO item;
    [SerializeField] int itemCount;

    public ItemSO Item
    {
        get { return item; }
        set { item = value; }
    }
    public int ItemCount
    {
        get { return itemCount; }
        set { itemCount = value; }
    }
    public ItemData()
    {

    }
}

