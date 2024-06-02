using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopCTRL : MonoBehaviour
{
    //Events to activate on shop close and open
    public event Action OnShopOpen;
    public event Action OnShopClose;

    [Header("References To UI elements")]
    [SerializeField] GameObject ShopUIWindow;
    [SerializeField] ItemUI ShopSlot_Prefab;
    [SerializeField] Transform ShopSlot_Container;

    [Header("Reference to the players UI inventory handler")]
    [SerializeField] InventoryUI InventoryUI;

    [Header("Total of UI items spawned")]
    [SerializeField] List<ItemUI> TotalUIItems;
    //Reference to the items that are being sold
    private List<ItemSO> _shopItems;

    //Static reference to self
    public static ShopCTRL Instance { get; private set; }
    //Reference to the player's inventory
    private Inventory _playersInventory;
    private void Awake()
    {
        Instance = this;
        _playersInventory = Inventory.GetInventory();
    }

    //Function to open the shop and capture the shop keepers inventory
    public void OpenShop(ShopKeeper npcTalked)
    {
        OnShopOpen?.Invoke();
        ShopUIWindow.SetActive(true);
        _shopItems = npcTalked.AvailableItems;
        UpdateItems();
    }

    //Function to close the shops UI
    public void CloseShop()
    {
        OnShopClose?.Invoke();
        ShopUIWindow.SetActive(false);
    }

    //Function to update all the UI Items parameters
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

    //Function to handle selling an item to the shop keeper
    public void SellItem(ItemSO item)
    {

        float sellingPrice = Mathf.Round(item.Price / 3);

        //Confirmation box before selling the item
        NotificationManager.Instance.ShowNotification($"It sells for {sellingPrice}, are you sure you want to sell?", false, 0,
           true, () =>
        {
            //Remove the item and update the UI
            _playersInventory.RemoveItem(item);
            UpdateItems();

            //Add Money
            MoneyHandler.Instance.AddMoney(sellingPrice);
            NotificationManager.Instance.ShowNotification($"Received {sellingPrice} from selling {item.Name}");
        });
    }

    //Function to handle buying an item from the shop keeper
    private void BuyItem(ItemSO item)
    {
        //Check if has money to pay the price
        if (MoneyHandler.Instance.CanPay(item.Price))
        {
            //Show confirmation box before buing
            NotificationManager.Instance.ShowNotification($"It costs a total of {item.Price}, are you sure you want to buy?", false, 0,
           true, () =>
             {
                 //Buy and add it to the players inventory
                 _playersInventory.AddItem(item);
                 UpdateItems();

                 //Remove Money
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
