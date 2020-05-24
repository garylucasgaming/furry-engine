using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle interactable objects
// Kris J

public class Interact : MonoBehaviour
{
    [SerializeField]
    private Canvas interactUI;
    private Player UserPlayer;

    private void Start() { 
    
        interactUI = GetComponentInChildren<Canvas>(true);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            UserPlayer = player.GetComponent<Player>();
            UserPlayer.canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if(player.tag == "Player")
        {
            UserPlayer = player.GetComponent<Player>();
            UserPlayer.canInteract = false;
        }
    }
}
