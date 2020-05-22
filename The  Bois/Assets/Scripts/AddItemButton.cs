using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemButton : MonoBehaviour
{
    public bool dandelion;
    public bool pumpkin;
    public bool bat;
    public InventoryManager IM;


   





    public void AddItem() {
        if (dandelion)
        {
            IM.inventory.AddItem(new Item { itemType = Item.ItemType.Dandelion, amount = 1 });
        }
        else if (pumpkin) {
            IM.inventory.AddItem(new Item { itemType = Item.ItemType.Pumpkin, amount = 1 });
        }
        else if (bat)
        {
            IM.inventory.AddItem(new Item { itemType = Item.ItemType.Bat, amount = 1 });
        }

    }

    public void RemoveItem() {

        if (dandelion)
        {
            IM.inventory.RemoveItem(new Item { itemType = Item.ItemType.Dandelion, amount = 1 });
        }
        else if (pumpkin)
        {
            IM.inventory.RemoveItem(new Item { itemType = Item.ItemType.Pumpkin, amount = 1 });
        }
        else if (bat)
        {
            IM.inventory.RemoveItem(new Item { itemType = Item.ItemType.Bat, amount = 1 });
        }
    }



}
