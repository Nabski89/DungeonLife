using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExterior : MonoBehaviour
{
    bool GoingAway = false;
    public GameObject ReplacementDoor;
    public Vector3 move;
    Vector3 home;

    void Start()
    {
        home = transform.position;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        DirectionTile NewRoom = other.GetComponent<DirectionTile>();
        if (NewRoom != null)
            GoingAway = true;
    }

  /*  void Update()
    {

        if (GoingAway == true)
        {            // Move our position a step closer to the target.
            var step = 0.1f * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, home + move, step);
            if (transform.position == home + move)
            {
                ReplacementDoor.SetActive(true);
                Destroy(gameObject);
            }

        }
    }
    */
}
