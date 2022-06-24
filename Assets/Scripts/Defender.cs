using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public bool InCombat;
    public Vector3 TargetPosition;
    void Start()
    {
        TargetPosition = transform.parent.position+Vector3.one;
    }
    public float MoveCooldown = 4;
    public float MoveCooldownTimer = 4;
    //raycasts want to be in fixed update. We are using this as our door check.
    void FixedUpdate()
    {
        //makes it so we only hit layer 7
        int layerMask = 1 << 7;
        //these are the debug lines so we can see what we are hitting.
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * 2, Color.red);
        //only fire when you're hit a room center
        //take a break at the new location
        if (transform.position == TargetPosition && transform.position != transform.parent.position+Vector3.one)
        {
            MoveCooldownTimer = MoveCooldown;
            Debug.Log("Lets go home");
            TargetPosition = transform.parent.position+Vector3.one;
        }

        if (transform.position == transform.parent.position+Vector3.one)
        {
            Debug.Log("Look for a route");
            //forward
            RaycastHit2D hitDown = Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector3.up), 2, layerMask);
            // if it doesn't hit anything
            TurnRight();
            if (hitDown.collider != null)
            {
                Debug.Log("Foward Hits " + hitDown.collider.gameObject.name);
            }
            if (hitDown.collider == null)
            {
                TargetPosition = transform.position + (3 * transform.TransformDirection(Vector3.right));
            }
        }

        //now we actually move
        if (InCombat == false)
        {
            if (MoveCooldownTimer <= 0)
            {
                var step = 1 * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, TargetPosition, step);
            }
            else
            {
                MoveCooldownTimer -= Time.deltaTime;
            }
        }
    }
    //this is just so we can call it from the door checker
    public void TurnRight()
    {
        transform.Rotate(0, 0, -90, Space.Self);
    }
    public void TurnLeft()
    {
        transform.Rotate(0, 0, 90, Space.Self);
    }
}