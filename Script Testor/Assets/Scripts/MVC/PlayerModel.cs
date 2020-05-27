using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    

    // movement variables
    [SerializeField] public bool isMoving = false;
    [SerializeField] public bool isJumping = false;
    [SerializeField] public bool wallJumped = false;
    [SerializeField] public bool isGrounded = false;
    [SerializeField] public bool isWallGrab = false;
    [SerializeField] public bool isDashing = false;
    [SerializeField] public bool hasDashed = false;
    [SerializeField] public bool isOnWallLeft = false;
    [SerializeField] public bool isOnWallRight = false;
    [SerializeField] public bool isOnWall = false;
    [SerializeField] public bool canMove = true;
    [SerializeField] public float jumpVelocity;
    public Vector2 movementVelocity;
    public float horizontalInput;
    public float verticalInput;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float slideSpeed;
    public float dashSpeed;
    public LayerMask groundLayers;
    public LayerMask wallLayers;


    //player stats. remove comments from ones you'd like to use
    [SerializeField] private float _playerSpeed;
    public float PlayerSpeed { get => _playerSpeed; set => _playerSpeed = value; }

    //[SerializeField] public float _playerHealth;
    //public float PlayerHealth { get => _playerHealth; set => _playerHealth = value; }

   // [SerializeField] public float _playerStamina;
   // public float PlayerStamina { get => _playerStamina; set => _playerStamina = value; }




    //player skills example
   // [SerializeField] public float _playerStrength;
    //public float PlayerStrength { get => _playerStrength; set => _playerStrength = value; }

    



    //gameObject components
    private Rigidbody2D playerRigidBody;


    
        


    //on Awake
    private void Awake()
    {
        //init rigidbody
        
        if (this.GetComponent<Rigidbody2D>()) { playerRigidBody = GetComponent<Rigidbody2D>();}
        else
        {
            this.gameObject.AddComponent<Rigidbody2D>();
            playerRigidBody = GetComponent<Rigidbody2D>();
            

        }



    }


    private void Update()
    {
       isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.5f, transform.position.y - 0.51f), groundLayers);
       isOnWallLeft = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.51f, transform.position.y - 0.5f), new Vector2(transform.position.x - 0.51f, transform.position.y + 0.5f), wallLayers);
       isOnWallRight = Physics2D.OverlapArea(new Vector2(transform.position.x + 0.51f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.51f, transform.position.y + 0.5f), wallLayers);
       isOnWall = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.51f, transform.position.y - 0.5f), new Vector2(transform.position.x - 0.51f, transform.position.y + 0.5f), wallLayers)
       || Physics2D.OverlapArea(new Vector2(transform.position.x + 0.51f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.51f, transform.position.y + 0.5f), wallLayers);
    }







}