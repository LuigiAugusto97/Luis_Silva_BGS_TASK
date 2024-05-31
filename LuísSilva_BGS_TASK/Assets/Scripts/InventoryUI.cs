using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    //Make Property For showing Money

    [Header("list of total items")]
    private Inventory inventoryUI;
    [SerializeField] ItemUI[] totalItems;


    private void Awake()
    {
        inventoryUI = Inventory.GetInventory();
    }
    private void Start()
    {
        UpdateItemList();
    }

    public void UpdateItemList()
    {
        // Clear Items
        for (int i = 0; i < totalItems.Length; i++)
        {
            totalItems[i].ClearItemUI();
        }

        if (inventoryUI._Inventory.Count <= 0) return;

        // Add Item from inventory to UI
        for (int i = 0; i < inventoryUI._Inventory.Count; i++)
        {
            totalItems[i].SetData(inventoryUI._Inventory[i]);
        }
    }

    //TODO Make it change item in character
    public void UseItem()
    {
       
    }
}
