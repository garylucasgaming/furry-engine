using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle interactable objects
// Kris J

public class Interact : MonoBehaviour
{
    public bool dandelion;
    public bool pumpkin;
    public bool bat;
    public InventoryManager IM;

    [SerializeField]
    [Header("Private Variables")]
    private Canvas interactUI;
    [SerializeField]
    private Player UserPlayer;


    private void Start() { 
    
        interactUI = GetComponentInChildren<Canvas>(true);
        interactUI.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            UserPlayer = player.GetComponent<Player>();
            UserPlayer.canInteract = true;
            interactUI.gameObject.SetActive(true);
            UserPlayer.currentInteractObj = this.GetComponent<Interact>();

        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if(player.tag == "Player")
        {
            UserPlayer = player.GetComponent<Player>();
            UserPlayer.canInteract = false;
            UserPlayer.currentInteractObj = null;
            interactUI.gameObject.SetActive(false);
        }
    }

    public void AddItem()
    {
        if (dandelion)
        {
            IM.inventory.AddItem(new Item { itemType = Item.ItemType.Dandelion, amount = 1 });
        }
        else if (pumpkin)
        {
            IM.inventory.AddItem(new Item { itemType = Item.ItemType.Pumpkin, amount = 1 });
        }
        else if (bat)
        {
            IM.inventory.AddItem(new Item { itemType = Item.ItemType.Bat, amount = 1 });
        }

    }
}
