using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Cauldron : MonoBehaviour
{

    public Transform itemSlotOne;
    public Transform itemSlotTwo;
    public Transform ingredientCheckBoxOne;
    public Transform ingredientCheckBoxTwo;
    public Cauldron cauldron;
    public InventoryManager IM;
    public int activeRecipe;
    public bool hasIngredientOne = false;
    public bool hasIngredientTwo = false;
    public bool addedIngredients = false;





    private void Awake()
    {
        

    }

    private void Start()
    {
        checkInventoryForIngredients();
        updateRecipeUI();
        activeRecipe = 0;
    }


    // sets active recipe
    public void setActiveRecipe(int recipeAdd) {
        if (activeRecipe == cauldron.recipeList.Count - 1)
        {
            activeRecipe = 0;

        } else if (activeRecipe == 0) {

            activeRecipe = cauldron.recipeList.Count - 1;

        } else {
            activeRecipe += recipeAdd;
        }

        if (cauldron.inventory.itemList.Count != 0) {
            foreach (Item item in cauldron.inventory.itemList) {
                IM.inventory.AddItem(item);
            }
            clearCauldron();
        }
        checkInventoryForIngredients();
        updateRecipeUI();
    }

    //check player inventory for ingredients to see if they have them. 
    public void checkInventoryForIngredients() {
        if (IM.inventory.GetItemList().Count == 0)
        {
            hasIngredientOne = false;
            hasIngredientTwo = false;
        }
        else
        {
            foreach (Item item in IM.inventory.GetItemList())
            {
                if (item.itemType == cauldron.recipeList[activeRecipe].ingredientOne.itemType)
                {
                    hasIngredientOne = true;
                    break;

                }
                else
                {
                    hasIngredientOne = false;
                }
            }
            foreach (Item item in IM.inventory.GetItemList())
            {
                if (item.itemType == cauldron.recipeList[activeRecipe].ingredientTwo.itemType)
                {
                    hasIngredientTwo = true;
                    break;
                }
                else
                {
                    hasIngredientTwo = false;
                }
            }
        }
        
    }

    public void updateRecipeUI (){
        //change ingredient images
        Image recipeImageOne = ingredientCheckBoxOne.Find("image").GetComponent<Image>();
        Image recipeImageTwo = ingredientCheckBoxTwo.Find("image").GetComponent<Image>();
        recipeImageOne.sprite = cauldron.recipeList[activeRecipe].ingredientOne.GetSprite();
        recipeImageTwo.sprite = cauldron.recipeList[activeRecipe].ingredientTwo.GetSprite();

        //change potion image
        Image potionImage = this.transform.Find("recipe side").transform.Find("potion selector").transform.Find("PotionSlot").transform.Find("image").GetComponent<Image>();
        potionImage.sprite = cauldron.recipeList[activeRecipe].potion.GetSprite();


        //change potion nameplate
        TextMeshProUGUI potionText = this.transform.Find("recipe side").transform.Find("potion selector").transform.Find("PotionSlot").transform.Find("PotionPlate").transform.Find("potionText").GetComponent<TextMeshProUGUI>();
        potionText.SetText(cauldron.recipeList[activeRecipe].Name);

        //hasingredientone
        if (hasIngredientOne == true)
        {
            ingredientCheckBoxOne.transform.Find("cross").gameObject.SetActive(false);
            ingredientCheckBoxOne.transform.Find("checkmark").gameObject.SetActive(true);
        }
        if (hasIngredientOne == false)
        {
            ingredientCheckBoxOne.transform.Find("cross").gameObject.SetActive(true);
            ingredientCheckBoxOne.transform.Find("checkmark").gameObject.SetActive(false);
        }

        //hasingredienttwo
        if (hasIngredientTwo == true)
        {
            ingredientCheckBoxTwo.transform.Find("cross").gameObject.SetActive(false);
            ingredientCheckBoxTwo.transform.Find("checkmark").gameObject.SetActive(true);
        }
        if (hasIngredientTwo == false)
        {
            ingredientCheckBoxTwo.transform.Find("cross").gameObject.SetActive(true);
            ingredientCheckBoxTwo.transform.Find("checkmark").gameObject.SetActive(false);
        }
    }



    public void addIngredients() {

        if (hasIngredientOne == true && hasIngredientTwo == true && cauldron.inventory.itemList.Count == 0) {

            //add to cauldron inventory
            cauldron.inventory.AddItem(cauldron.recipeList[activeRecipe].ingredientOne);
            cauldron.inventory.AddItem(cauldron.recipeList[activeRecipe].ingredientTwo);

            //remove from player inventory
            IM.inventory.RemoveItem(cauldron.inventory.itemList[0]);
            IM.inventory.RemoveItem(cauldron.inventory.itemList[1]);
            
            //set cauldron slot images
            Image imageOne = itemSlotOne.Find("image").GetComponent<Image>();
            Image imageTwo = itemSlotTwo.Find("image").GetComponent<Image>();
            itemSlotOne.Find("image").gameObject.SetActive(true);
            itemSlotTwo.Find("image").gameObject.SetActive(true);

            //set sprite to  cauldron inventory images
            imageOne.sprite = cauldron.inventory.itemList[0].GetSprite();
            imageTwo.sprite = cauldron.inventory.itemList[1].GetSprite();
            addedIngredients = true;
            checkInventoryForIngredients();
            updateRecipeUI();
        }
    }

    public void clearCauldron() {
        cauldron.inventory = new Inventory();
        Image imageOne = itemSlotOne.Find("image").GetComponent<Image>();
        Image imageTwo = itemSlotTwo.Find("image").GetComponent<Image>();
        itemSlotOne.Find("image").gameObject.SetActive(false);
        itemSlotTwo.Find("image").gameObject.SetActive(false);
        addedIngredients = false;
    }

    public void brew() {

        if (addedIngredients == true)
        {
            //clear cauldron inventory
            clearCauldron();

            //give player the potion
            
            IM.inventory.AddItem(new Item {itemType = cauldron.recipeList[activeRecipe].potion.itemType, amount = 1 });

            addedIngredients = false;
        } 


    }





}
