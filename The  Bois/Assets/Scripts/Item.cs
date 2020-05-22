using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    //item types in game
    public enum ItemType {
        Dandelion,
        Pumpkin,
        Bat

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
            case ItemType.Bat: return ItemAssets.Instance.batSprite;

        }
    }

}
