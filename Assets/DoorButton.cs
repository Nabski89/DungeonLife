using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject DOOR;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (DOOR.active)
        {
            DOOR.SetActive(false);
        }
        else
        {
            DOOR.SetActive(true);
        }
    }
}
