using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderEvent : MonoBehaviour
{
    public int MaxEvents = 24;

    //we have reset this to zero in our camera controller so you can start a new game without grumbling
    public static int EventCount = 0;
    // up the range of event difficulty over time
    void Start()
    {
        EventCount += 3;
        NewEvent();
    }

    public void NewEvent()
    {
        {
            int RNG = Mathf.Min(MaxEvents, Random.Range(0, EventCount));
            GameObject EventToSpawn = Resources.Load<GameObject>("Events/Invader/InvadeRandom" + RNG.ToString());
        }
    }
}
