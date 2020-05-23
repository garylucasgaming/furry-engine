using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    //list of items in game(resources and potions
    public enum ItemType {
        Dandelion,
        Pumpkin,
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
            case ItemType.Dandelion: return ItemAssets.Instance.dandelionSprite;
            case ItemType.Pumpkin: return ItemAssets.Instance.pumpkinSprite;
            case ItemType.Bat:  return ItemAssets.Instance.batSprite;
            case ItemType.HealingPotion: return ItemAssets.Instance.healingPotionSprite;
            case ItemType.StrengthPotion: return ItemAssets.Instance.strengthPotionSprite;

        }
    }

}
