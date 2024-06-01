using System;
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
    public void RemoveItem(ItemSO item)
    {
        if (CheckIfItemPresent(item))
        {
            var itemToBeRemoved = _inventory.First(invItem => invItem.Item == item);
            _inventory.Remove(itemToBeRemoved);
        }
    }

    //To add an Item to the Inventory
    public void AddItem(ItemSO itemToAdd)
    {
        _inventory.Add(new ItemData()
        {
            Item = itemToAdd,
            ItemInUse = false
        });
    }

    //To check if inventory Contains Item
    public bool CheckIfItemPresent(ItemSO itemToCheck)
    {
        var itemAlreadyinInventory = _inventory.FirstOrDefault(item => item.Item == itemToCheck);
        if (itemAlreadyinInventory != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Always find Players Inventory
    public static Inventory GetInventory()
    {
        return FindObjectOfType<Player_CTRL>().GetComponent<Inventory>();
    }
}

[Serializable]
public class ItemData
{
    [SerializeField] ItemSO item;
    [SerializeField] bool itemInUse;

    public ItemSO Item
    {
        get { return item; }
        set { item = value; }
    }
    public bool ItemInUse
    {
        get { return itemInUse; }
        set { itemInUse = value; }
    }
    public ItemData()
    {

    }
}

