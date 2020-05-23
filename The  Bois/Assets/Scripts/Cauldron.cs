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

    //put recipes here
    public void GenerateRecipeList() {
        //healing potion
        AddRecipe(new Recipe {  recipeType = Recipe.RecipeType.HealingPotionRecipe, firstIngredient = Item.ItemType.Dandelion, secondIngredient = Item.ItemType.Pumpkin});
        //strength potion
        AddRecipe(new Recipe { recipeType = Recipe.RecipeType.StrengthPotionRecipe, firstIngredient = Item.ItemType.Bat, secondIngredient = Item.ItemType.Pumpkin });

    }


    //method to add a recipe to the recipe list
    public void AddRecipe(Recipe recipe) {
        recipeList.Add(recipe);
    }

    //access to recipelist
    public List<Recipe> GetRecipeList() {
        return recipeList;
    }


    //add ingredients to cauldron iinventory IF player has ingredients, checked against the current selected recipe, in their inventory
    public void AddIngredients() { }


    //if items in cauldron inventory match items on current selected recipe, then  remove  from cauldron
    //inventory and add the current selected recipe's related potion  to the players inventory
    public void Brew() { }


    

    //recipe ui

    //cauldron ui



}
