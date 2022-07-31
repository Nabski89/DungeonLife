using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderEvent : MonoBehaviour
{
    public int MaxEvents = 24;

    static EventManager EventTarget;

    //we have reset this to zero in our camera controller so you can start a new game without grumbling
    public static int EventCount = 0;
    // up the range of event difficulty over time
    void Start()
    {
        EventCount += 3;

        //find our event manager and set it as the target so that we don't have to find it every time
        if (EventTarget == null)
        {
            EventManager Event = GameObject.FindObjectOfType<EventManager>();
            EventTarget = Event;
        }

        NewEvent();
    }

    public void NewEvent()
    {
        {
            //get a random number
            int RNG = Mathf.Min(MaxEvents, Random.Range(0, EventCount));
            //pick one of the events
            GameObject EventToSpawn = Resources.Load<GameObject>("Events/Invader/IR" + RNG.ToString());
            GameObject Canvas = GameObject.Find("Canvas");
            Debug.Log("Events/Invader/IR" + RNG.ToString());

            // get our location and set it to spawn in the middle of that room
            Debug.Log("location of invade event is " + transform.position);
            Component[] EventButton;

            EventButton = EventToSpawn.GetComponentsInChildren(typeof(UIButton));

            if (EventButton != null)
            {
                foreach (UIButton EventEached in EventButton)
                {
                    EventEached.GetComponent<UIButton>().LocationCreate = transform.position;
                    Debug.Log("We have a button" + EventEached.GetComponent<UIButton>().LocationCreate);
                }
            }
            EventTarget.SpawnEvent(EventToSpawn);
        }
    }
}
