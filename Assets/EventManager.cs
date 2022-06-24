using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject EventLoc1;
    public GameObject EventLoc2;
    public GameObject EventLoc3;
    // Start is called before the first frame update

    public GameObject MiniEvent;
    void Start()
    {

    }

    // Update is called once per frame
    float eventtimer = 1;
    void Update()
    {
        eventtimer -= Time.deltaTime;
        if (eventtimer < 0)
        {
            SpawnEvent("Main Text", "Text 1", "Text 2", "Text 3");
        }
    }

    void SpawnEvent(string MainText, string Option1, string Option2, string Option3)
    {
        if (EventLoc1.transform.childCount > 0)
        {
            if (EventLoc2.transform.childCount < 1)
            {
                //spawn in slot 2
                Spawn(EventLoc2);
            }
            else if (EventLoc3.transform.childCount < 1)
            {
                //spawn in slot 3
                Spawn(EventLoc3);
            }
        }
        else
        {
            //spawn in slot 1
            Spawn(EventLoc1);
        }
    }

    void Spawn(GameObject EventLoc)
    {
        Instantiate(MiniEvent, EventLoc.transform);
        eventtimer += 1;
    }
}
