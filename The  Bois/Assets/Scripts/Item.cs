using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    //list of items in game(resources and potions
    public enum ItemType {
        Orchid,
        Lavender,
        Bat,
        HealingPotion, 
        StrengthPotion

    }

    //accessors
    public ItemType itemType;
    public int amount;

    //the sprite for each item
    public Sprite GetSprite() {
        switch (itemType) {
            default:
            case ItemType.Orchid: return ItemAssets.Instance.orchidSprite;
            case ItemType.Lavender: return ItemAssets.Instance.lavenderSprite;
            case ItemType.Bat:  return ItemAssets.Instance.batSprite;
            case ItemType.HealingPotion: return ItemAssets.Instance.healingPotionSprite;
            case ItemType.StrengthPotion: return ItemAssets.Instance.strengthPotionSprite;

        }
    }

}
