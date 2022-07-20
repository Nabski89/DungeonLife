using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject EventLoc1;
    public GameObject EventLoc2;
    public GameObject EventLoc3;

    public GameObject MiniEvent;
    public float EventTrigger;
    public float EventWeight;

    // Update is called once per frame
    float eventtimer = 60;
    void Update()
    {
        eventtimer -= Time.deltaTime;
        if (eventtimer < 0)
        {
            EventWeight += 1;
            eventtimer += 60;
        }
        if (EventWeight > EventTrigger)
        {
            EventWeight = 0;
            EventTrigger += 1;
            SpawnEvent(MiniEvent);
        }

    }

    void SpawnEvent(GameObject EventSpawned)
    {
        if (EventLoc1.transform.childCount > 0)
        {
            if (EventLoc2.transform.childCount < 1)
            {
                //spawn in slot 2
                Spawn(EventLoc2, MiniEvent);
            }
            else if (EventLoc3.transform.childCount < 1)
            {
                //spawn in slot 3
                Spawn(EventLoc3, MiniEvent);
            }
        }
        else
        {
            //spawn in slot 1
            Spawn(EventLoc1, MiniEvent);
        }
    }

    void Spawn(GameObject EventLoc, GameObject MiniEventSpawned)
    {
        Instantiate(MiniEventSpawned, EventLoc.transform);
    }
}
