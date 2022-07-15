using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryResource : MonoBehaviour
{
    int CarryLimit = 0;



    // Update is called once per frame

    public void OnTriggerEnter2D(Collider2D other)
    {
        ResourceController Resource = other.GetComponent<ResourceController>();

        if (Resource != null && CarryLimit > 0)
        {

        }
    }
}
