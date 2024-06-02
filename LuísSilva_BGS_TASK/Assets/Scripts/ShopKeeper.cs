using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractables
{  
    [Header("List of the shop keepers items to sell")]
    [SerializeField] List<ItemSO> _availableItems;

    public List<ItemSO> AvailableItems
    {
        get { return _availableItems; }
    }

    //Funtion to call when the player interact with him
    public void Interact()
    {
        //Open the shop UI
        ShopCTRL.Instance.OpenShop(this);
    }
}
