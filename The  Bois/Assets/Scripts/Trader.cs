using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
    [SerializeField] InventoryManager IM;
    [SerializeField] Player player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        IM = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>(); 
    }

    public void SellPotions()
    {
        Debug.Log("Selling potions");

        if (IM.inventory.GetItemList().Count == 0)
        {
            //Tell player they don't have items/potions
            return;
        }
        else
        {
            for (int i = IM.inventory.GetItemList().Count - 1; i >= 0; i--)
            {
                Item item = IM.inventory.GetItemList()[i];
                if (item.itemType == Item.ItemType.HealingPotion ||
                    item.itemType == Item.ItemType.StrengthPotion)
                {
                    IM.inventory.RemoveItem(item);
                    player.money++;
                }
            }
        }
    }
}
