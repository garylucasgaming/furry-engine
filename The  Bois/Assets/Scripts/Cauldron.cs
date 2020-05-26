using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    //inits
    public Inventory inventory;
    public List<Recipe> recipeList;
  

    public void Awake()
    {
        //more inits
        inventory = new Inventory();
        recipeList = new List<Recipe>();
        GenerateRecipeList();
    }

    public void Start()
    {

        
    }

    //put recipes here
    public void GenerateRecipeList() {
        //healing potion recipe
        AddRecipe(new Recipe { recipeType = Recipe.RecipeType.HealingPotionRecipe, potion = new Item { itemType = Item.ItemType.HealingPotion, amount = 1 }, ingredientOne =  new Item {itemType = Item.ItemType.Orchid, amount = 1 }, ingredientTwo = new Item { itemType = Item.ItemType.Lavender, amount = 1 }, Name = "Healing Potion" } );

        //strength potion recipe
        AddRecipe(new Recipe { recipeType = Recipe.RecipeType.StrengthPotionRecipe, potion = new Item { itemType = Item.ItemType.StrengthPotion, amount = 1 }, ingredientOne = new Item { itemType = Item.ItemType.Bat, amount = 1 }, ingredientTwo = new Item { itemType = Item.ItemType.Orchid, amount = 1 }, Name = "Strength Potion" });

    }


    //method to add a recipe to the recipe list
    public void AddRecipe(Recipe recipe) {
        recipeList.Add(recipe);
    }

    //access to recipelist
    public List<Recipe> GetRecipeList() {
        return recipeList;
    }


    
    
    


}
