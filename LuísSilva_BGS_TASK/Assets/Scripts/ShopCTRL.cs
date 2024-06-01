using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopCTRL : MonoBehaviour
{
    public static ShopCTRL Instance { get; private set; }

    public event Action OnShopOpen;

    [SerializeField] GameObject ShopUIWindow;
    [SerializeField] ItemUI ShopSlot_Prefab;
    [SerializeField] Transform ShopSlot_Container;

    [SerializeField] InventoryUI InventoryUI;

    [SerializeField] List<ItemUI> TotalUIItems;
    private List<ItemSO> _shopItems;

    private Inventory _playersInventory;
    private void Awake()
    {
        Instance = this;
        _playersInventory = Inventory.GetInventory();
    }

    public void OpenShop(ShopKeeper npcTalked)
    {
        OnShopOpen?.Invoke();
        ShopUIWindow.SetActive(true);
        _shopItems = npcTalked.AvailableItems;
        UpdateItems();

    }


    private void UpdateItems()
    {
        // Clear Items
        foreach (Transform child in ShopSlot_Container.transform)
        {
            Destroy(child.gameObject);
            if (TotalUIItems.Count != 0)
            {
                TotalUIItems.Clear();
            }
        }
        // Add Item from inventory to UI
        foreach (var item in _shopItems)
        {
            var itemUI = Instantiate(ShopSlot_Prefab, ShopSlot_Container);
            TotalUIItems.Add(itemUI);
            itemUI.SetShopData(item, () => { BuyItem(item); });
        }

        InventoryUI.UpdateItemShopList(this);
    }

    public void SellItem(ItemSO item)
    {

        float sellingPrice = Mathf.Round(item.Price / 3);
        NotificationManager.Instance.ShowNotification($"It sells for {sellingPrice}, are you sure you want to sell?", false, 0,
           true, () =>
        {
            _playersInventory.RemoveItem(item);
            UpdateItems();

            //Add Money
            MoneyHandler.Instance.AddMoney(sellingPrice);
            NotificationManager.Instance.ShowNotification($"Received {sellingPrice} from selling {item.Name}");
        });
    }
    private void BuyItem(ItemSO item)
    {
        if (MoneyHandler.Instance.CanPay(item.Price))
        {
            //Show confirmation box
            NotificationManager.Instance.ShowNotification($"It costs a total of {item.Price}, are you sure you want to buy?", false, 0,
           true, () =>
             {
                 //Yes
                 _playersInventory.AddItem(item);
                 UpdateItems();

                 //Add Money
                 MoneyHandler.Instance.SpendMoney(item.Price);

                 NotificationManager.Instance.ShowNotification($"Received {item.Name} from the purchase");

             });

        }
        else
        {
            NotificationManager.Instance.ShowNotification("You can't afford that.", false, 1f);
        }
    }
}
