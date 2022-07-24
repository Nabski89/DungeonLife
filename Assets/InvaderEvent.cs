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
            //get a random number
            int RNG = Mathf.Min(MaxEvents, Random.Range(0, EventCount));
            //pick one of the events
            GameObject EventToSpawn = Resources.Load<GameObject>("Events/Invader/IR" + RNG.ToString());
            GameObject Canvas = GameObject.Find("Canvas");
            Debug.Log("Events/Invader/IR" + RNG.ToString());


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
            
            Instantiate(EventToSpawn, Canvas.transform.position, Quaternion.identity, Canvas.transform);


            //EventToSpawn.GetComponent<LocationCreate = transform.position;



        }
    }
}
