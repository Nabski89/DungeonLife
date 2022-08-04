using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelverEvent : MonoBehaviour
{

    public int MaxEvents = 4;
    public int RandomEventCount = 0;

    static EventManager EventTarget;

    //we have reset this to zero in our camera controller so you can start a new game without grumbling
    public static int EventCount = 0;
    // up the range of event difficulty over time
    void Start()
    {


        //find our event manager and set it as the target so that we don't have to find it every time
        if (EventTarget == null)
        {
            EventManager Event = GameObject.FindObjectOfType<EventManager>();
            EventTarget = Event;
        }

        if (Random.Range(0, 2) == 1 || EventCount == MaxEvents)
            RandomEvent();
        else
        {
            StoryEvent();
            EventCount = Mathf.Max(EventCount + 1, MaxEvents);
        }

    }

    public void RandomEvent()
    {
        {
            //get a random number
            int RNG = Random.Range(0, RandomEventCount);
            //pick one of the events
            GameObject EventToSpawn = Resources.Load<GameObject>("Events/Delver/Random/DRR" + RNG.ToString());
            GameObject Canvas = GameObject.Find("Canvas");
            Debug.Log("Events/Delver/Random/DRR" + RNG.ToString());

            // get our location and set it to spawn in the middle of that room
            Debug.Log("Random Delver Event location event is " + transform.position);
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
    public void StoryEvent()
    {
        {
            //get a random number
            int RNG = Mathf.Min(MaxEvents, Random.Range(0, EventCount));
            //pick one of the events
            GameObject EventToSpawn = Resources.Load<GameObject>("Events/Delver/Story/DRS" + EventCount.ToString());
            GameObject Canvas = GameObject.Find("Canvas");
            Debug.Log("Events/Delver/Story/DRS" + RNG.ToString());

            // get our location and set it to spawn in the middle of that room
            Debug.Log("Story event location is " + transform.position);
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
