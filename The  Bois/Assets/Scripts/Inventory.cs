using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Inventory  
{

    public event EventHandler OnItemListChanged;

    //init of item list for the inventory
    public List<Item> itemList;


    //inventory constructor
    public Inventory() {
        itemList = new List<Item>();

       
       
    }


    //add an item to our inventory list
    public void AddItem(Item item) {
        bool itemAlreadyInInventory = false;

        foreach (Item inventoryItem in itemList) {
            if (inventoryItem.itemType == item.itemType) {
                inventoryItem.amount += item.amount;
                itemAlreadyInInventory = true;
            }
        }
        if (!itemAlreadyInInventory) { itemList.Add(item); }
        
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }


    //remove item from inventory
    public void RemoveItem(Item item) {
        Item itemInInventory = null;
        foreach (Item inventoryItem in itemList)
        {
            if (inventoryItem.itemType == item.itemType)
            {
                inventoryItem.amount -= item.amount;
                itemInInventory = inventoryItem;
            }
        }
        if (itemInInventory != null && itemInInventory.amount <=0) { itemList.Remove(itemInInventory); }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);

    }

    //public accessor for itemlist
    public List<Item> GetItemList() {
        return itemList;
    }

}
