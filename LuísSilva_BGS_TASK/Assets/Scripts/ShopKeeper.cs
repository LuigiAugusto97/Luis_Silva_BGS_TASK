using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractables
{  
    [SerializeField] List<ItemSO> _availableItems;

    public List<ItemSO> AvailableItems
    {
        get { return _availableItems; }
    }

    public void Interact()
    {
        ShopCTRL.Instance.OpenShop(this);
    }
}
