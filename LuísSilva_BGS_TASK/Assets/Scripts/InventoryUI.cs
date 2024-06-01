using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    //Make Property For showing Money

    [SerializeField] GameObject InventoryWindow;

    [SerializeField] BodyPartAnimation _HairPart;
    [SerializeField] BodyPartAnimation _BodyPart;

    public BodyPartAnimation HairPart
    {
        get { return _HairPart; }
    }
    public BodyPartAnimation BodyPart
    {
        get { return _BodyPart; }
    }

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


        // Add Item from inventory to UI
        for (int i = 0; i < _playerInventory._Inventory.Count; i++)
        {
            int index = i;
            ItemData itemToEquip = _playerInventory._Inventory[index];
            TotalItems_Menu[i].SetInventoryData(itemToEquip, () => { EquipItem(itemToEquip); });
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

        // Add Item from inventory to UI
        for (int i = 0; i < _playerInventory._Inventory.Count; i++)
        {
            int index = i;
            ItemSO itemToSell = _playerInventory._Inventory[index].Item;
            TotalItems_Shop[i].SetInventoryData(_playerInventory._Inventory[i], () => { shop.SellItem(itemToSell);});
        }
    }

    //TODO Make it change item in character
    public void EquipItem(ItemData itemToBeEquiped)
    {
        Debug.Log(itemToBeEquiped.Item.name);
        if (itemToBeEquiped.ItemInUse)
        {
            NotificationManager.Instance.ShowNotification("You are already using that item!");
            return;
        }
        if (itemToBeEquiped.Item.Type == ItemType.Head)
        {
            HairPart.ChangeParts(itemToBeEquiped);
        }
        else if (itemToBeEquiped.Item.Type == ItemType.Body)
        {
            BodyPart.ChangeParts(itemToBeEquiped);
        }
    }
}
