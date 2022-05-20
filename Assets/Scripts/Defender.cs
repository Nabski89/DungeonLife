using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public Rigidbody2D rb;
    void start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public int cooldown;
    void Update()
    {
        cooldown += 1;
        if (cooldown > Random.Range(.8f, 2.1f) * 30)
        {
            cooldown = 0;

            move();
        }
    }

    void move()
    {
        int MoveDir = Random.Range(0, 4);
        if (MoveDir == 0)
        {
            rb.velocity = Vector3.right;
        }
        if (MoveDir == 1)
        {
            rb.velocity = Vector3.left;
        }
        if (MoveDir == 2)
        {
            rb.velocity = Vector3.up;
        }
        if (MoveDir == 3)
        {
            rb.velocity = Vector3.down;
        }
    }
}
