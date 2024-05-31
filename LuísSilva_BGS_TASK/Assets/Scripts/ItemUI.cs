using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] Image ItemIcon;
    [SerializeField] TextMeshProUGUI ItemCount;

    public void SetData(ItemData itemUI)
    {
        ItemIcon.enabled = true;
        ItemIcon.sprite = itemUI.Item.Icon;

        ItemCount.enabled = true;
        ItemCount.text = $"x {itemUI.ItemCount}";
    }
    public void SetShopData(ItemSO shopItem)
    {
        ItemIcon.sprite = shopItem.Icon;
        ItemCount.text = $"{shopItem.Price}$";
    }

    public void ClearItemUI()
    {
        ItemIcon.enabled = false;
        ItemCount.enabled = false;
    }
}
