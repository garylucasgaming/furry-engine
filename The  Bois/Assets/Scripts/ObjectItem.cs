using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectItem : MonoBehaviour
{
    public Item.ItemType itemType;



    public void destroyObject() {

        if (this.transform.parent.name == "BatAsset")
        {
            Debug.Log("parent destroyed");
           Destroy(this.transform.parent.gameObject);
            
        }
        else
        {
            Debug.Log(" destroyed");
            Destroy(this.gameObject);
        }

    }


    

    
}
