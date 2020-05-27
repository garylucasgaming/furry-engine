using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerModel playerModel;
    private Rigidbody2D rigidBody;
    private Vector2 newDirection;
    public bool snappyMovement = false;
    public enum GameType { TopDown, SideScroller };
    [SerializeField] public GameType currentGameType;
    private float xInput;
    private float yInput;

    //awake
    private void Awake()
    {
        playerModel = this.GetComponent<PlayerModel>();
        rigidBody = this.GetComponent<Rigidbody2D>();
        

    }

    //start
    private void Start()
    {
        SetRigidBody();
    }


    // update
    private void Update()
    {

        if (currentGameType == GameType.SideScroller)
        {
            UpdateMovementSideScroller();
            UniqueKeys();


        }
        if (currentGameType == GameType.TopDown)
        {
            UpdateMovementTopDown();
            UniqueKeys();

        }


    }

    //this is where you will put your extra stuff for the game you are making, individual and unique key presses
    private void UniqueKeys()
    {
        //example
        //if (Input.GetButton("Fire2")) { //do a thing }

    }



    //possibles
    //create a dashwait() to keep a cooldown on dashing 





    //set the rigidbody based on game type
    private void SetRigidBody()
    {

        if (currentGameType == GameType.SideScroller)
        {
            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            rigidBody.gravityScale = 1;
        }

        if (currentGameType == GameType.TopDown)
        {
            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            rigidBody.gravityScale = 0;
        }




    }

    //platformer walk/run
    private void Walk(Vector2 dir)
    {
        if (!playerModel.canMove) { return; }

        if (!playerModel.wallJumped)
        {
            rigidBody.velocity = (new Vector2(dir.x * playerModel.PlayerSpeed, rigidBody.velocity.y));
        }
        else
        {
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, (new Vector2(dir.x * playerModel.PlayerSpeed, rigidBody.velocity.y)), .5f * Time.deltaTime);
        }
        
        
    }

    //platformer wall slide or climb or shimmy
    private void WallSlide()
    {
        if (playerModel.isOnWall && !playerModel.isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, -playerModel.slideSpeed);
        }
    }

    //platformer wall grab
    private void WallGrab()
    {
        if (playerModel.isOnWall && Input.GetKey(KeyCode.LeftShift))
        {
            playerModel.isWallGrab = true;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, yInput * playerModel.PlayerSpeed);
        }
        else { playerModel.isWallGrab = false; }
    }

    // Platformer Basic jump code
    private void Jump(Vector2 direction)
    {

            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
            rigidBody.velocity = direction * playerModel.jumpVelocity;

    }

    // Platformer Advanced jump code(basic jump must be on)
    private void BetterJump()
    {
        // rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);


        //if tap jump, only jump a little, if hold jump higher. also change velocity on fall back down
        if (rigidBody.velocity.y < 0)
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (playerModel.fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigidBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (playerModel.lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    //platformer wall jump
    private void WallJump()
    {
        Vector2 wallDirection = playerModel.isOnWallRight ? Vector2.left : Vector2.right;

        Jump(Vector2.up / 1.5f + wallDirection / 1.5f);
        playerModel.wallJumped = true;
    
    }

    //platformer/ sidescroller dash
    private void Dash(float x, float y)
    {

        playerModel.hasDashed = true;
        playerModel.isDashing = true;
        rigidBody.velocity = Vector2.zero;
        rigidBody.velocity += new Vector2(x, y).normalized * playerModel.dashSpeed;
    }

    //movement update for sidescroller/platformer
    public void UpdateMovementSideScroller()
    {
        if (!snappyMovement)
        {
            xInput = Input.GetAxis("Horizontal");
            yInput = Input.GetAxis("Vertical");
        }
        else
        {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");
        }
        
        Vector2 direction = new Vector2(xInput, yInput);
        if (playerModel.isGrounded && !playerModel.isDashing) { playerModel.wallJumped = false; }
        Walk(direction);
        WallGrab();

        //for wallslide
        if (!playerModel.isWallGrab && xInput != 0) { WallSlide(); }

        //for wall dash
        if (playerModel.isGrounded || playerModel.isOnWall) { playerModel.hasDashed = false; playerModel.isDashing = false; }

        if (Input.GetButtonDown("Fire1") && !playerModel.hasDashed)
        {
            if (xInput != 0 || yInput != 0)
            {
                Dash(xInput, yInput);
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (playerModel.isGrounded)
            {
                Jump(Vector2.up);
            }
            if (playerModel.isOnWall)
            {
                WallJump();
            }
            
        }

        BetterJump();



    }



    //movement update for topdown
    public void UpdateMovementTopDown()
    {
        if (!snappyMovement)
        {
            playerModel.movementVelocity.x = xInput = Input.GetAxis("Horizontal");
            playerModel.movementVelocity.y = yInput = Input.GetAxis("Vertical");
        }
        else
        {
            playerModel.movementVelocity.x = xInput = Input.GetAxisRaw("Horizontal");
            playerModel.movementVelocity.y = yInput = Input.GetAxisRaw("Vertical");
        }
         
        Vector2 direction = new Vector2(xInput, yInput);

       
            rigidBody.MovePosition(rigidBody.position + playerModel.movementVelocity * playerModel.PlayerSpeed * Time.fixedDeltaTime);

            
        


    }
}
