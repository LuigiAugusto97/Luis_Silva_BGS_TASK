using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("Reference to the inventory UI Screen")]
    [SerializeField] GameObject InventoryWindow;

    [Header("Reference to button on screen to open inventory")]
    [SerializeField] GameObject UIOpenButton;

    [Header("Reference the animation scripts of the equipable items")]
    [SerializeField] BodyPartAnimation _BodyParts; 

    [Header("List of Static Inventory slots in the inventory screen")]
    [SerializeField] ItemUI[] TotalItems_Menu;
    [Header("List of Static Inventory slots in the shopping screen")]
    [SerializeField] ItemUI[] TotalItems_Shop;

    //Reference to the players inventory
    private Inventory _playerInventory;

    private void Awake()
    {
        _playerInventory = Inventory.GetInventory();
    }

    //Funtion to handle the inventory window
    public void HandleInventoryUI()
    {
        if (!InventoryWindow.activeSelf)
        {
            InventoryWindow.SetActive(true);
            UIOpenButton.SetActive(false);
            UpdateItemList();
        }
        else
        {
            UIOpenButton.SetActive(true);
            InventoryWindow.SetActive(false);
        }
    }

    //Funtion that updates the parameters in the UI item in the inventory screen
    private void UpdateItemList()
    {
        // Clear Items
        for (int i = 0; i < TotalItems_Menu.Length; i++)
        {
            TotalItems_Menu[i].ClearItemUI();
        }

        if (_playerInventory.InventoryProperty.Count <= 0) return;


        // Add Item from inventory to UI and add on click event to equip item
        for (int i = 0; i < _playerInventory.InventoryProperty.Count; i++)
        {
            int index = i;
            ItemData itemToEquip = _playerInventory.InventoryProperty[index];
            TotalItems_Menu[i].SetInventoryData(itemToEquip, () => { EquipItem(itemToEquip); });
        }
    }

    //Funtion that updates the parameters in the UI item in the shopping screen
    public void UpdateItemShopList( ShopCTRL shop)
    {
        // Clear Items
        for (int i = 0; i < TotalItems_Shop.Length; i++)
        {
            TotalItems_Shop[i].ClearItemUI();
        }

        if (_playerInventory.InventoryProperty.Count <= 0) return;

        // Add Item from inventory to UI and add on click event to sell the item
        for (int i = 0; i < _playerInventory.InventoryProperty.Count; i++)
        {
            int index = i;
            ItemData itemToSell = _playerInventory.InventoryProperty[index];
            TotalItems_Shop[i].SetInventoryData(_playerInventory.InventoryProperty[i], () =>
            {
                if (!itemToSell.ItemInUse)
                {
                    shop.SellItem(itemToSell.Item);
                }
                else
                {
                    NotificationManager.Instance.ShowNotification("You cannot sell an Item that you are wearing!");
                }
            });
        
        }
    }

    //Function that equips an item to the player and shows it visually
    public void EquipItem(ItemData itemToBeEquiped)
    {
        
        if (itemToBeEquiped.ItemInUse)
        {
            NotificationManager.Instance.ShowNotification("You are already using that item!");
            return;
        }
        _BodyParts.ChangeParts(itemToBeEquiped);
        _playerInventory.EquipItem(itemToBeEquiped);
        UpdateItemList();
    }
}
