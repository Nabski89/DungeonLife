using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChecker : MonoBehaviour
{

    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        DoorBlocker controller = other.GetComponent<DoorBlocker>();
        if (controller != null)
        {
            DelverController DelverParent = GetComponentInParent<DelverController>();
            //   Debug.Log("WAKE UP MR ANDERSON");
      //      DelverParent.TurnRight();
        }
    }

}