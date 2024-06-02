using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [Header("Common to all items")]
    [SerializeField] Image ItemIcon;
    [SerializeField] Image ItemBorder;
    [SerializeField] Button Button;

    [Header("Exclusive to shop UI")]
    [SerializeField] TextMeshProUGUI ItemPrice;
    [SerializeField] TextMeshProUGUI ItemName;

    //Function to set all the parameters from an item data and handle the on click event
    public void SetInventoryData(ItemData itemUI, Action onClickEvent)
    {
        ItemIcon.enabled = true;
        ItemIcon.sprite = itemUI.Item.Icon;
        if (itemUI.ItemInUse)
        {
            ItemBorder.enabled = true;
        }
        Button.interactable = true;
        Button.onClick.AddListener(() => { onClickEvent?.Invoke(); });
    }

    //Function to reset the parameters of the item UI
    public void ClearItemUI()
    {
        Button.interactable = false;
        ItemIcon.enabled = false;
        ItemBorder.enabled = false;
        Button.onClick.RemoveAllListeners();
    }

    //Function to set all the parameters from an item data and handle the on click event, but for the shop items specifically
    public void SetShopData(ItemSO shopItem, Action onClickEvent)
    {
        Button.onClick.RemoveAllListeners();
        ItemIcon.sprite = shopItem.Icon;
        ItemName.text = shopItem.Name;
        ItemPrice.text = $"{shopItem.Price}$";
        Button.onClick.AddListener(()=> { onClickEvent?.Invoke(); } );
    }


}
