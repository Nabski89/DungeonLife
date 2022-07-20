using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEvent : MonoBehaviour
{
    public GameObject Delver;
    public GameObject Resource;
    public GameObject Invader;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.RoomEventTracker -= 1;
        int RandomRangeValue = 0
        + Random.Range(0, EventManager.RoomEventTrackerDelver)
        + Random.Range(0, EventManager.RoomEventTrackerResource)
        + Random.Range(0, EventManager.RoomEventTrackerInvader);

        if (Random.Range(0, EventManager.RoomEventTracker) < RandomRangeValue)
            Event();

        Destroy(this);
    }


//spawn an event, then make it less likely that that type of event will happen in the future, we probably need to have this weighted better than
    void Event()
    {
        int RRValue = Random.Range(0, EventManager.RoomEventTrackerDelver + EventManager.RoomEventTrackerResource + EventManager.RoomEventTrackerInvader);
        if (RRValue < EventManager.RoomEventTrackerDelver)
        {
            Instantiate(Delver, transform.position, Quaternion.identity, transform);
            EventManager.RoomEventTrackerDelver -= 1;
        }
        if (RRValue < EventManager.RoomEventTrackerDelver + EventManager.RoomEventTrackerResource)
        {
            Instantiate(Resource, transform.position, Quaternion.identity, transform);
            EventManager.RoomEventTrackerResource -= 1;
        }
        else
        {
            Instantiate(Invader, transform.position, Quaternion.identity, transform);
            EventManager.RoomEventTrackerInvader -= 1;
        }
         EventManager.RoomEventTracker += 4;
    }
}