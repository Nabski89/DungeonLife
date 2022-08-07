using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour
{
    public GameObject Room;
    //GameObject RoomCenter;

    public bool valid = false;
    public int cost = 5;
    float TextDelay = 5;
    public GameObject Text;
    public GameObject ExpansionRoom;
    public GameObject DoorCheck;
    void Start()
    {
        Invoke("NotValid", 0.05f);

        //oh boy we are hard coding our starting tile
        if (Vector3.Distance(ManaController.Instance.transform.position, transform.position) < 2)
            Expandiate();
    }
    void OnMouseDown()
    {
        Expandiate();
        /*
                    //activate the text, get the ability to edit it, display the cost, then if you click it while text is up you buy it
            if (Text.activeSelf == false)
            {
                Text.SetActive(true);
                Text.GetComponent<TMPro.TextMeshPro>().text = InvaderSpawner.DungeonSize * 10 + " Ѩ";
                TextDelay = 5;
            }
            else
                            Expandiate();
            */
    }
    public void Expandiate()
    {
        ExpansionRoom.SetActive(true);
        ManaController.Spend(InvaderSpawner.DungeonSize * cost);
        ExpansionRoom.transform.SetParent(transform.parent);
        //we are just going to clear out the list and re-add all valid spawn locations
        foreach (var NextRoom in GameObject.FindObjectsOfType<Expand>())
        {
            //this activates Room that are close enough to connect to an existing room
            if (Vector3.Distance(NextRoom.transform.position, transform.position) < 4)
                //make sure we aren't adding ourself here
                if (Vector3.Distance(NextRoom.transform.position, transform.position) > 1)
                {
                    NextRoom.valid = true;
                    GetComponent<PolygonCollider2D>().enabled = true;
                    GetComponent<SpriteRenderer>().enabled = true;
                    NextRoom.AddMe();
                    Debug.Log("Added 1 room to Invader spawn points, there are now " + InvaderSpawner.SpawnPointList.Count + " invader spawn locations");
                }
        }


        //this builds the door, we still need to put it in some kind of door builder button thing then make the door script
        foreach (var RoomWeAreNextTo in GameObject.FindObjectsOfType<DirectionTile>())
        {
            Debug.Log("FOUND A DIRECTION TILE THIS FAR AWAY" + Vector2.Distance(RoomWeAreNextTo.transform.position, transform.position));
            //this activates Room that are close enough to connect to an existing room
            if (Vector2.Distance(RoomWeAreNextTo.transform.position, transform.position) < 4)
                //make sure we aren't adding ourself here
                if (Vector2.Distance(RoomWeAreNextTo.transform.position, transform.position) > 1)
                {
                    GameObject Doory = Instantiate(DoorCheck, (transform.position + RoomWeAreNextTo.transform.position) / 2, Quaternion.identity, transform.parent);

                    if (RoomWeAreNextTo.transform.position.x == transform.position.x)
                        //Door Rotation Check
                        Doory.transform.Rotate(0, 0, 90, Space.Self);
                    BuilderButton.DoorBuilderList.Add(Doory);
                }
        }

        InvaderSpawner.DungeonSize += 1;

        InvaderSpawner.SpawnPointList.Remove(gameObject);
        Debug.Log("Removed 1 room from Invader spawn points, there are now " + InvaderSpawner.SpawnPointList.Count + " invader spawn locations. The dungeon size is now " + InvaderSpawner.DungeonSize);
        BuilderButton.Instance.RemoveFromRoomList(gameObject);
        //remove this next line if you want them to minimize after purchase
        BuilderButton.Activate = false;
        BuilderButton.ShowRoomExpansions();

        ExpansionRoom.GetComponent<RoomEvent>().RoomEventGo();
        Destroy(gameObject);
    }
    void Update()
    {
        /*       if (valid == true)
               {
                   if (ManaController.ManaSpend > 0)
                   {
                       if (GetComponent<PolygonCollider2D>().enabled == true)
                       {
                           GetComponent<PolygonCollider2D>().enabled = false;
                           GetComponent<SpriteRenderer>().enabled = false;
                           Text.SetActive(false);
                           TextDelay = 0;
                       }
                   }

                   if (ManaController.ManaSpend <= 0)
                   {
                       {
                           GetComponent<PolygonCollider2D>().enabled = true;
                           GetComponent<SpriteRenderer>().enabled = true;
                       }
                   }
       */
        TextDelay -= 1 * Time.deltaTime;
        if (TextDelay < 0)
            Text.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Make a new room on hitting the area game object
        Area Area = other.GetComponent<Area>();
        if (Area != null && ExpansionRoom == null)
        {
            //     Debug.Log("Spawn A Room");
            ExpansionRoom = Instantiate(Room, transform.position, Quaternion.identity, transform);
        }
    }

    void AddMe()
    {
        if (InvaderSpawner.SpawnPointList.Contains(gameObject) != true)
            InvaderSpawner.SpawnPointList.Add(gameObject);
    }

    void NotValid()
    {
        DirectionTile HasRoom = GetComponentInChildren(typeof(DirectionTile), true) as DirectionTile;

        if (HasRoom != null)
        {
            ExpansionRoom.SetActive(false);
            BuilderButton.Instance.AddToRoomList(gameObject);
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
            Destroy(gameObject);
    }
    public void EnableIfValid()
    {
        if (valid == true)
        {
            GetComponent<PolygonCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    public void DisableForTheButton()
    {
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

}