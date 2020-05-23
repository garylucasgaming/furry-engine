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
    public Item potion;
    public Item ingredientOne;
    public Item ingredientTwo;
    public string Name;
    



   
}
