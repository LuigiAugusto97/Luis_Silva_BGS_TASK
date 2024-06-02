using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enum of the game states that the game has
public enum GameStates { FreeRoam, InventoryManagment, Shop}
public class GameCTRL : MonoBehaviour
{
    [Header("Reference to the player")]
    [SerializeField] Player_CTRL Player;
    [Header("Reference to the player inventory")]
    [SerializeField] InventoryUI PlayerInventory;

    //The current state of the game
    private GameStates states;


    private void Awake()
    {
        states = GameStates.FreeRoam;    
    }

    private void Start()
    {
        //Handle the events of opening and closing the shop
        ShopCTRL.Instance.OnShopOpen += () => { states = GameStates.Shop; };
        ShopCTRL.Instance.OnShopClose += () => { states = GameStates.FreeRoam; };
    }

    //Handle all the events according to the current state
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
                HandleInventoryWindow(false);
            }
        }
        else if (states == GameStates.InventoryManagment)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                HandleInventoryWindow(true);
            }
        }
        else if (states == GameStates.Shop)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CloseShopWindow();
            }
        }
    }

    //Funtio to handle the opening and closing of the inventory in the UI
    public void HandleInventoryWindow(bool isOpen)
    {
        if (!isOpen)
        {
            Player.HandleMovement(false);
            PlayerInventory.HairPart.HandleMovement(false);
            PlayerInventory.BodyPart.HandleMovement(false);
            PlayerInventory.HandleInventoryUI();
            states = GameStates.InventoryManagment;
        }
        else
        {
            Player.HandleMovement(false);
            PlayerInventory.HairPart.HandleMovement(false);
            PlayerInventory.BodyPart.HandleMovement(false);
            PlayerInventory.HandleInventoryUI();
            states = GameStates.FreeRoam;
        }
     
    }

    //Funtio to handle the  closing of the shop window in the UI
    public void CloseShopWindow()
    {
        Player.HandleMovement(true);
        PlayerInventory.HairPart.HandleMovement(true);
        PlayerInventory.BodyPart.HandleMovement(true);
        ShopCTRL.Instance.CloseShop();
    }
}
