using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventMini : MonoBehaviour
{
    public GameObject Event;
    Image m_Graphic;
    float timer = 3;
    float waitTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Graphic from the GameObject
        m_Graphic = GetComponent<Image>();
    }



    // Update is called once per frame
    void Update()
    {
        m_Graphic.color += Time.deltaTime / waitTime * Color.red;
        m_Graphic.color -= Time.deltaTime / waitTime * Color.cyan;
        m_Graphic.fillAmount -= Time.deltaTime / waitTime;

        timer -= Time.deltaTime;
        if (timer < 0)
            EventTrigger();
    }


    public void EventTrigger()
    {
        float Speed = Time.timeScale;
        Time.timeScale = 0;

        GameObject Canvas = GameObject.Find("Canvas");
        GameObject EventSpawned = (GameObject)Instantiate(Event, Canvas.transform, false);
        EventSpawned.GetComponent<EventPopup>().Speed = Speed;
        Destroy(gameObject);
    }
}
