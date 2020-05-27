using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller for the player character
// Kris J

public class Player : MonoBehaviour
{
    //set player speed and interact bool
    public float Speed;
    public bool canInteract;

    //player money for selling potions 
    public int money;

    //Holds player RigidBody and speed
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    //audio manager
    public GameObject audiomanager;
    public PauseMenu pauseMenu;


    //player collision
    
    Collider2D collisionObject;

    //Main canvas for reference
     public Canvas canvas;
    public bool inventoryOpen = false;
    public bool cauldronOpen = false;

    //inventory manager reference
    public InventoryManager IM;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("AudioManager") == null) {
            Instantiate(audiomanager);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //attaach player RB to the component in script
        rb = this.GetComponent<Rigidbody2D>();
        
        canInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        //get axis input(up,down,left,right or w,a,s,d) and apply that to the vector2 mov input and multiply by speed
        //only if cauldron isn't open
        if (!cauldronOpen)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * Speed;

        }



        //open inventory
        //if cauldron not open
        //if (Input.GetKeyDown(KeyCode.I) && inventoryOpen == false && cauldronOpen == false)
        //{
        //    canvas.transform.Find("UI_Inventory").gameObject.SetActive(true);
        //    IM.uiInventory.RefreshInventoryItems();
        //    inventoryOpen = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.I) && inventoryOpen == true && cauldronOpen == false)
        //{
        //    canvas.transform.Find("UI_Inventory").gameObject.SetActive(false);
        //    inventoryOpen = false;
        //}



        //interact 
        if (canInteract == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (cauldronOpen == true)
                {
                    if (collisionObject.GetComponent<Cauldron>().inventory.itemList.Count != 0)
                    {
                        foreach (Item item in collisionObject.GetComponent<Cauldron>().inventory.itemList)
                        {
                            IM.inventory.AddItem(item);
                        }
                        canvas.transform.Find("UI_Cauldron").GetComponent<UI_Cauldron>().clearCauldron();
                    }

                    //canvas.transform.Find("UI_Inventory").gameObject.SetActive(false);
                    canvas.transform.Find("UI_Cauldron").gameObject.SetActive(false);
                    cauldronOpen = false;
                }
                else if (!PauseMenu.gameIsPaused) pauseMenu.PauseGame();
                else pauseMenu.ResumeGame();
            }

                if (Input.GetKeyDown(KeyCode.E))
                {

                if (!collisionObject.CompareTag("Cauldron") && !collisionObject.CompareTag("Trader"))
                {
                    IM.inventory.AddItem(new Item { itemType = collisionObject.GetComponent<ObjectItem>().itemType, amount = 1 });
                   collisionObject.GetComponent<ObjectItem>().destroyObject();

                }

                //trader
                if (collisionObject.CompareTag("Trader"))
                {
                    Debug.Log("found trader, gonna try to sell potions");
                    collisionObject.GetComponentInChildren<Trader>().SellPotions();
                }

                //cauldron
                if (collisionObject.CompareTag("Cauldron") && cauldronOpen == false)
                {
                    //canvas.transform.Find("UI_Inventory").gameObject.SetActive(true);
                    canvas.transform.Find("UI_Cauldron").gameObject.SetActive(true);
                    IM.uiInventory.RefreshInventoryItems();
                    cauldronOpen = true;
                }
                else if (cauldronOpen == true)
                {
                    //canvas.transform.Find("UI_Inventory").gameObject.SetActive(false);
                    canvas.transform.Find("UI_Cauldron").gameObject.SetActive(false);
                    cauldronOpen = false;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseMenu.gameIsPaused) pauseMenu.PauseGame();
            else pauseMenu.ResumeGame();
        }

    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionObject = other;
    }


    private void FixedUpdate()
    {
        //actually move the thing
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

   


}
