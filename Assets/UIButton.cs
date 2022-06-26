using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour
{
    public int ButtonNum = 1;
    public KeyCode PushIt = KeyCode.Alpha1;
    Button ThisButton;

    RectTransform rectTransform;
    //if we start another event we don't want to unpause yet


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        Vector2 position = rectTransform.anchoredPosition;
        position.y = 50;
        ThisButton = GetComponent<Button>();
        while (transform.parent.GetComponentsInChildren<UIButton>().GetLength(0) > ButtonNum)
        {
            ButtonNum += 1;
            position.y += 50;
        }

        rectTransform.anchoredPosition = position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(PushIt))
        {
            ThisButton.onClick.Invoke();
        }
    }

    public void PushingTheButtonDoesItAll()
    {
        //for mana
        GainMana();
        //for things that can be put in rooms
        NewSpawn();
        //for things that can upgrade thigns put in rooms
        NewUpgrade();
        //for new gameobjects
        NewCreate();
        //for new events to follow up on this one
        NewEvent();
        EventPopup EventPup = GetComponentInParent<EventPopup>();
        if (EventPup != null)
        {
            EventPup.Unpause();
        }
    }
    public bool ManaB;
    public int ManaBoon;
    public void GainMana()
    {
        if (ManaB == true)
            ManaController.Gain(ManaBoon);
    }


    public bool UpgradeSpawn;
    public GameObject NewBuy;
    public void NewSpawn()
    {
        if (UpgradeSpawn == true)
        {
            Debug.Log("Can now spawn" + NewBuy);
            UpgradeHolder.AddToSpawnList(NewBuy);
        }
    }

    public bool Upgrade;
    public GameObject Upgradee;
    public void NewUpgrade()
    {
        if (UpgradeSpawn == true)
        {
            UpgradeHolder.AddToUpgradeList(Upgradee);
        }
    }

    public bool Create;
    public GameObject Createe;
    public Vector3 LocationCreate;
    public void NewCreate()
    {
        if (Create == true)
            Instantiate(Createe, LocationCreate, Quaternion.identity);
    }
    public bool Event;
    public string PickAnEvent;
    public Vector3 LocationEvent;
    public void NewEvent()
    {
        if (Event == true)
        {
            Debug.Log("Spawned Event " + PickAnEvent);
            GameObject EventToSpawn = Resources.Load<GameObject>(PickAnEvent);
            Debug.Log(EventToSpawn);
            GameObject Canvas = GameObject.Find("Canvas");
            Instantiate(EventToSpawn, Canvas.transform.position, Quaternion.identity, Canvas.transform);
        }
    }
}