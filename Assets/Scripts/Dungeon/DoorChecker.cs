using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChecker : MonoBehaviour
{
    void Start()
    {
        Destroy(this, 5);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        DoorButton DoorButtonScript = GetComponent<DoorButton>();

        DoorBlocker controller = other.GetComponent<DoorBlocker>();
        if (controller != null)
        {
            if (DoorButtonScript.DOOR1 == null)
                DoorButtonScript.DOOR1 = other.gameObject;
            else
            {
                DoorButtonScript.DOOR2 = other.gameObject;
                DoorButtonScript.DoorTrigger();
            }
        }
    }

}