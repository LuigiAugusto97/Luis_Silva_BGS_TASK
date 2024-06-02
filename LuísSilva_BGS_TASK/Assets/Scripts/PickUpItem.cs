using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractables
{
    [Header("Item to be picked up")]
    [SerializeField] ItemSO ItemToPickUP;

    [Header("Notification to appear once is picked up")]
    [SerializeField] string NotificationText;

    //Boolean to check if it has been picked up before
    private bool hasBeenPickedUp = false;

    //Reference to the players inventory
    private Inventory _playerInventory;
    private void Awake()
    {
        _playerInventory = Inventory.GetInventory();
    }
    //Function used on being interacted with
    public void Interact()
    {
        if (!hasBeenPickedUp)
        {
            _playerInventory.AddItem(ItemToPickUP);
            hasBeenPickedUp = true;
            NotificationManager.Instance.ShowNotification(NotificationText);
        }
    }
}
