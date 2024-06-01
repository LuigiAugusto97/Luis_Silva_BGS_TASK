using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] Image ItemIcon;
    [SerializeField] Image ItemBorder;
    [SerializeField] TextMeshProUGUI ItemPrice;
    [SerializeField] TextMeshProUGUI ItemName;
    [SerializeField] Button Button;

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
    public void ClearItemUI()
    {
        Button.interactable = false;
        ItemIcon.enabled = false;
        ItemBorder.enabled = false;
        Button.onClick.RemoveAllListeners();
    }

    public void SetShopData(ItemSO shopItem, Action onClickEvent)
    {
        Button.onClick.RemoveAllListeners();
        ItemIcon.sprite = shopItem.Icon;
        ItemName.text = shopItem.Name;
        ItemPrice.text = $"{shopItem.Price}$";
        Button.onClick.AddListener(()=> { onClickEvent?.Invoke(); } );
    }


}
