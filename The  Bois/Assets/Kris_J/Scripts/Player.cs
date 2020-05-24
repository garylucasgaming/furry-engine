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

    //Holds player RigidBody and speed
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

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
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * Speed;

        if(canInteract == true)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Test");
            }
        }

    }

    private void FixedUpdate()
    {
        //actually move the thing
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

   


}
