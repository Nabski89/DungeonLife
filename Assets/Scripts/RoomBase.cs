using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBase : MonoBehaviour
{
    public float RoomThreat = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public int cooldown = 0;
    void Update()
    {
        transform.Rotate(00.0f, 00.0f, 01.0f, Space.Self);
        cooldown += 1;
        if (cooldown > 60)
        {
            cooldown = 0;
        }
    }
}
