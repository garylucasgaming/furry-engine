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
        newResource.transform.SetParent(transform);

    }

    // Update is called once per frame
    void Update()
    {
        //If no children, begin/continue countdown
        if (transform.childCount == 0)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 0f)
            {
                timerEnded();
            }
        }
    }

    private void timerEnded()
    {
        var newResource = Instantiate(resource, transform.position, transform.rotation);
        newResource.transform.SetParent(transform);

        targetTime = 10f;
    }
}
