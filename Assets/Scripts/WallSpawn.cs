using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    public bool OutsideWall = false;
    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        WallSpawn Wall = other.GetComponent<WallSpawn>();
        if (Wall != null && OutsideWall == true)
        {
            Destroy(gameObject);
        }
    }
}
