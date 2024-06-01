using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] Image ItemIcon;
    [SerializeField] TextMeshProUGUI ItemPrice;
    [SerializeField] TextMeshProUGUI ItemName;
    [SerializeField] Button Button;

    public void SetInventoryData(ItemData itemUI, Action onClickEvent)
    {
        Button.onClick.RemoveAllListeners();
        ItemIcon.enabled = true;
        ItemIcon.sprite = itemUI.Item.Icon;

        Button.interactable = true;
        Button.onClick.AddListener(() => { onClickEvent?.Invoke(); });
    }
    public void ClearItemUI()
    {
        Button.interactable = false;
        ItemIcon.enabled = false;
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
