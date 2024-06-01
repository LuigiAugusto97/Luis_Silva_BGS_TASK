using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    //Make Property For showing Money

    [SerializeField] GameObject InventoryWindow;
    

    [Header("list of total items")]
    private Inventory _playerInventory;
    [SerializeField] ItemUI[] TotalItems_Menu;
    [SerializeField] ItemUI[] TotalItems_Shop;


    private void Awake()
    {
        _playerInventory = Inventory.GetInventory();
    }

    public void HandleInventoryUI()
    {
        if (!InventoryWindow.activeSelf)
        {
            InventoryWindow.SetActive(true);
            UpdateItemList();
        }
        else
        {
            InventoryWindow.SetActive(false);
        }
    }

    private void UpdateItemList()
    {
        // Clear Items
        for (int i = 0; i < TotalItems_Menu.Length; i++)
        {
            TotalItems_Menu[i].ClearItemUI();
        }

        if (_playerInventory._Inventory.Count <= 0) return;

        int index = 0;
        // Add Item from inventory to UI
        for (int i = 0; i < _playerInventory._Inventory.Count; i++)
        {
            index = i;
            TotalItems_Menu[i].SetInventoryData(_playerInventory._Inventory[i], () => { EquipItem(_playerInventory._Inventory[index]); });
        }
    }

    public void UpdateItemShopList( ShopCTRL shop)
    {
        // Clear Items
        for (int i = 0; i < TotalItems_Shop.Length; i++)
        {
            TotalItems_Shop[i].ClearItemUI();
        }

        if (_playerInventory._Inventory.Count <= 0) return;

        int index = 0;
        // Add Item from inventory to UI
        for (int i = 0; i < _playerInventory._Inventory.Count; i++)
        {
            index = i;
            TotalItems_Shop[i].SetInventoryData(_playerInventory._Inventory[i], () => { shop.SellItem(_playerInventory._Inventory[index].Item);});
        }
    }

    //TODO Make it change item in character
    public void EquipItem(ItemData itemToBeEquiped)
    {
        Debug.Log("Equip");
    }
}
