using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("List of the items that are in the players inventory")]
    [SerializeField] List<ItemData> _inventory;
    public List<ItemData> InventoryProperty
    {
        get { return _inventory; }
    }

    //Function to remove an item from the players inventory
    public void RemoveItem(ItemSO item)
    {
        if (CheckIfItemPresent(item))
        {
            var itemToBeRemoved = _inventory.First(invItem => invItem.Item == item);
            _inventory.Remove(itemToBeRemoved);
        }
    }

    //Function to add an item to the players inventory
    public void AddItem(ItemSO itemToAdd)
    {
        _inventory.Add(new ItemData()
        {
            Item = itemToAdd,
            ItemInUse = false
        });
    }

    //Function to check if inventory contains Item
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

    //Function to handle which item is currently equiped
    public void EquipItem(ItemData itemEquiped)
    {
        foreach( ItemData item in _inventory)
        {
            if (item != itemEquiped && item.Item.Type == itemEquiped.Item.Type && item.ItemInUse)
            {
                item.ItemInUse = false;
                break;
            }
        }
        itemEquiped.ItemInUse = true;

    }

    //Always find Players Inventory
    public static Inventory GetInventory()
    {
        return FindObjectOfType<Player_CTRL>().GetComponent<Inventory>();
    }
}

//Class created to handle the items 
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

