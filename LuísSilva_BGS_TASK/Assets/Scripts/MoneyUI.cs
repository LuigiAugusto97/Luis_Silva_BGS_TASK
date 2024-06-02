using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    //Reference for the text compente displaying the variable money
    [SerializeField] TextMeshProUGUI MoneyTxt;

    private void Awake()
    {
        //Add listener to event and set the new amount of money to UI
        MoneyHandler.Instance.OnMoneyChanged += SetMoneyUI;
    }
    private void OnEnable()
    {
        SetMoneyUI();
    }

    //Function to update UI with the variable money
    private void SetMoneyUI()
    {
        MoneyTxt.text = MoneyHandler.Instance.Money + "$";
    }
}
