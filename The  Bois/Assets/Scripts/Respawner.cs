using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public float targetTime = 10f;
    public GameObject resource;


    private void Awake()
    {
        var newResource = Instantiate(resource, transform.position, transform.rotation);
        newResource.transform.SetParent(this.transform);

    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0f) {
            timerEnded();
        }
       
    }

    private void timerEnded()
    {
        if (this.transform.childCount == 0)
        {
            var newResource = Instantiate(resource, transform.position, transform.rotation);
            newResource.transform.SetParent(this.transform);
            
            targetTime = 10f;
        }
       
    }
}
