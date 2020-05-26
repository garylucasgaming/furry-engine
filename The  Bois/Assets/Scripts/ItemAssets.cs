using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    

    //the sprite which will need to be populated
    public Sprite lavenderSprite;
    public Sprite orchidSprite;
    public Sprite batSprite;
    public Sprite healingPotionSprite;
    public Sprite strengthPotionSprite;


}
