using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    //Variable that represent the Player's Money
    [SerializeField] float money;
    public float Money
    {
        get { return money; }
        set { money = value; }
    }

    //Evento to trigger on any change on the variable money
    public event Action OnMoneyChanged;

    //Static reference of self
    public static MoneyHandler Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    //Function to add float amount to variable money
    public void AddMoney(float amount)
    {
        money += amount;
        OnMoneyChanged?.Invoke();
    }

    //Function to decrease float amount to variable money
    public void SpendMoney(float amount)
    {
        money -= amount;
        OnMoneyChanged?.Invoke();
    }

    //Boolean check to see if variable money can be decreased by float amount
    public bool CanPay(float amount)
    {
        return amount <= money;
    }
}
