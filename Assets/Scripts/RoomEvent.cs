using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEvent : MonoBehaviour
{
    public GameObject Delver;
    public GameObject Resource;
    public GameObject Invader;

    //spawn an event, then make it less likely that that type of event will happen in the future, we probably need to have this weighted better than
    void Event()
    {
        //check to make sure we don't spawn at our start location
        if (ManaController.Instance.transform.position.x == transform.position.x && ManaController.Instance.transform.position.y == transform.position.y)
            Destroy(this);


        int RRValue = Random.Range(0, EventManager.RoomEventTracker);


        // we reset to zero, then add the base value each time so that the longer we go without something the more likely it is we get that event type
        EventManager.RoomEventTrackerDelver += 3;
        EventManager.RoomEventTrackerResource += 5;
        EventManager.RoomEventTrackerInvader += 7;

        Debug.Log("Room Event Roll (Delver Resource Invader) " + EventManager.RoomEventTrackerDelver + " " + EventManager.RoomEventTrackerResource + " " + EventManager.RoomEventTrackerInvader);

        if (RRValue < EventManager.RoomEventTrackerDelver)
        {
            Instantiate(Delver, transform.position, Quaternion.identity, transform);
            EventManager.RoomEventTrackerDelver = 0;
        }
        else if (RRValue < EventManager.RoomEventTrackerDelver + EventManager.RoomEventTrackerResource)
        {
            Instantiate(Resource, transform.position, Quaternion.identity, transform);
            EventManager.RoomEventTrackerResource = 0;
        }
        else if (RRValue < EventManager.RoomEventTrackerDelver + EventManager.RoomEventTrackerResource + EventManager.RoomEventTrackerInvader)
        {
            Instantiate(Invader, transform.position, Quaternion.identity, transform);
            EventManager.RoomEventTrackerInvader = 0;
        }



    }

    public void RoomEventGo()
    {
        /*
        EventManager.RoomEventTracker += 2;
        int RandomRangeValue = 0
        + Random.Range(0, EventManager.RoomEventTrackerDelver)
        + Random.Range(0, EventManager.RoomEventTrackerResource)
        + Random.Range(0, EventManager.RoomEventTrackerInvader);

        if (Random.Range(0, EventManager.RoomEventTracker) < RandomRangeValue)

        */
        Event();


    }
}