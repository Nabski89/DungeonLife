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
        MoveCamera();
        if (Event == false)
            foreach (var Camera in GameObject.FindObjectsOfType<CameraController>())
            {
                Camera.UnPause();
            }
        Destroy(transform.parent.gameObject);
    }
    public int ManaBoone;
    public void GainMana()
    {
            ManaController.Gain(ManaBoone);
    }


    public int RandSpawn = 0;
    public GameObject[] Spawne;
    public void NewSpawn()
    {
        if (Spawne.Length != 0)
        {
            if (RandSpawn == 0)
            {
                int i = 0;
                while (i < Spawne.Length)
                {
                    UpgradeHolder.AddToSpawnList(Spawne[i]);
                    i += 1;
                }
            }
            else
                while (RandSpawn > 0)
                {
                    UpgradeHolder.AddToSpawnList(Spawne[Random.Range(0, Spawne.Length)]);
                    RandSpawn -= 1;
                }
        }
    }

    public int RandUpgrade = 0;
    public GameObject[] Upgradee;
    public void NewUpgrade()
    {
        if (Upgradee.Length != 0)
        {
            if (RandUpgrade == 0)
            {
                int i = 0;
                while (i < Upgradee.Length)
                {
                    UpgradeHolder.AddToUpgradeList(Upgradee[i]);
                    i += 1;
                }
            }
            else
                while (RandUpgrade > 0)
                {
                    UpgradeHolder.AddToUpgradeList(Upgradee[Random.Range(0, Upgradee.Length)]);
                    RandUpgrade -= 1;
                }
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

    public bool MoveCam;
    public void MoveCamera()
    {
        if (MoveCam == true)
        {
            foreach (var Camera in GameObject.FindObjectsOfType<CameraController>())
            {
                Camera.transform.position = new Vector3(LocationCreate.x, LocationCreate.y, -10);
            }
        }
    }
}