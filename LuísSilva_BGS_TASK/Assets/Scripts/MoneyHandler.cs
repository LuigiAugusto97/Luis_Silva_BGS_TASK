using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] float money;
    public float Money
    {
        get { return money; }
        set { money = value; }
    }
    public static MoneyHandler Instance { get; private set; }

    public event Action OnMoneyChanged;

    private void Awake()
    {
        Instance = this;
    }
    public void AddMoney(float amount)
    {
        money += amount;
        OnMoneyChanged?.Invoke();
    }
    public void SpendMoney(float amount)
    {
        money -= amount;
        OnMoneyChanged?.Invoke();
    }

    public bool CanPay(float amount)
    {
        return amount <= money;
    }
}
