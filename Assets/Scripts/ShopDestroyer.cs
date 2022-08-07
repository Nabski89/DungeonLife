using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Builder Shop = other.GetComponent<Builder>();

        if (Shop != null)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}