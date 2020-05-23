using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe 
{
    //list of recipes
    public enum RecipeType {

        HealingPotionRecipe,
        StrengthPotionRecipe

    }

    public RecipeType recipeType;
    public Item.ItemType firstIngredient;
    public Item.ItemType secondIngredient;
    



   
}
