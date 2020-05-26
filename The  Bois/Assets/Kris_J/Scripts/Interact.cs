using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle interactable objects
// Kris J

public class Interact : MonoBehaviour
{
    [SerializeField]
    private Player UserPlayer;

    

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            UserPlayer = player.GetComponent<Player>();
            UserPlayer.canInteract = true;
            this.transform.Find("objectCanvas").gameObject.SetActive(true);
            
            
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if(player.tag == "Player")
        {
            UserPlayer = player.GetComponent<Player>();
            UserPlayer.canInteract = false;
            this.transform.Find("objectCanvas").gameObject.SetActive(false);
        }
    }
}
