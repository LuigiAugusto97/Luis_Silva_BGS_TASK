using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates { FreeRoam, InventoryManagment, Shop }
public class GameCTRL : MonoBehaviour
{
    [SerializeField] Player_CTRL Player;
    [SerializeField] InventoryUI PlayerInventory;

    private GameStates states;


    private void Awake()
    {
        states = GameStates.FreeRoam;    
    }

    private void Start()
    {
        ShopCTRL.Instance.OnShopOpen += () => { states = GameStates.Shop; };
    }

    void Update()
    {
        if (states == GameStates.FreeRoam)
        {
            Player.HandleMovement(true);
            PlayerInventory.HairPart.HandleMovement(true);
            PlayerInventory.BodyPart.HandleMovement(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player.Interact();
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                Player.HandleMovement(false);
                PlayerInventory.HairPart.HandleMovement(false);
                PlayerInventory.BodyPart.HandleMovement(false);
                PlayerInventory.HandleInventoryUI();
                states = GameStates.InventoryManagment;
            }
        }
        else if (states == GameStates.InventoryManagment)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Player.HandleMovement(false);
                PlayerInventory.HandleInventoryUI();
                states = GameStates.FreeRoam;
            }
        }
        else if (states == GameStates.Shop)
        {

        }
    }
}
