using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MoneyTxt;
    private void Awake()
    {
        MoneyHandler.Instance.OnMoneyChanged += SetMoneyUI;
    }
    private void OnEnable()
    {
        SetMoneyUI();
    }
    private void SetMoneyUI()
    {
        MoneyTxt.text = MoneyHandler.Instance.Money + "$";
    }
}
