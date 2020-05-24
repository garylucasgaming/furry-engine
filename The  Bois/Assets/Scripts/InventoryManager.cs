using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //inventory init accessible only by this manager
    public Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;

    private void Awake()
    {

        //generate the inventory
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

    }

   
}
