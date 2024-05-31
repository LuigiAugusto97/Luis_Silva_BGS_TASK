using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCTRL : MonoBehaviour
{
    public static ShopCTRL Instance;

    public event Action OnShopOpen;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenShop(ShopKeeper npcTalked)
    {
        OnShopOpen?.Invoke();
    }
}
