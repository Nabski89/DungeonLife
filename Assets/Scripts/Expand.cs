using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour
{
    public GameObject Room;
    //GameObject RoomCenter;

    public bool valid = false;
    public int cost = 10;
    float TextDelay = 5;
    bool GoodLocation = false;
    public GameObject Text;
    public GameObject ExpansionRoom;
    void Start()
    {
        Invoke("NotValid", 0.1f);
        //    GetComponent<PolygonCollider2D>().enabled = false;
        //  GetComponent<SpriteRenderer>().enabled = false;
    }
    void OnMouseDown()
    {
        {
            //activate the text, get the ability to edit it, display the cost, then if you click it while text is up you buy it
            if (Text.activeSelf == false)
            {
                Text.SetActive(true);
                Text.GetComponent<TMPro.TextMeshPro>().text = InvaderSpawner.DungeonSize * 10 + " Ѩ";
                TextDelay = 5;
            }
            else
            {
                ExpansionRoom.SetActive(true);
                ManaController.Spend(InvaderSpawner.DungeonSize * cost);

                Debug.Log(transform.position);
                //we are just going to clear out the list and re-add all valid spawn locations
                InvaderSpawner.SpawnPointList.Clear();
                foreach (var NextRoom in GameObject.FindObjectsOfType<Expand>())
                {
                    //this activates Room that are close enough to connect to an existing room
                    if (Vector3.Distance(NextRoom.transform.position, transform.position) < 4)
                    {
                        NextRoom.valid = true;
                    }
                    if (NextRoom.valid == true)
                        NextRoom.Invoke("AddMe", 1);
                }

                InvaderSpawner.DungeonSize += 1;
                Debug.Log("There are currently " + InvaderSpawner.SpawnPointList.Count + "invader spawn locations");
                Destroy(gameObject);
            }
        }
    }
    void Update()
    {
        if (valid == true)
        {
            if (ManaController.ManaSpend > 0)
            {
                if (GetComponent<BoxCollider2D>().enabled == true)
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    GetComponent<SpriteRenderer>().enabled = false;
                    Text.SetActive(false);
                    TextDelay = 0;
                }
            }

            if (ManaController.ManaSpend <= 0)
            {
                {
                    GetComponent<BoxCollider2D>().enabled = true;
                    GetComponent<SpriteRenderer>().enabled = true;
                }
            }

            TextDelay -= 1 * Time.deltaTime;
            if (TextDelay < 0)
                Text.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Make a new room on hitting the area game object
        Area Area = other.GetComponent<Area>();
        if (Area != null && ExpansionRoom == null)
        {
            GoodLocation = true;
            Debug.Log("Spawn A Room");
            ExpansionRoom = Instantiate(Room, transform.position, Quaternion.identity, transform.parent);
            //       ExpansionRoom.SetActive(false);
        }

        DirectionTile controller = other.GetComponent<DirectionTile>();
        if (controller != null)
        {
            InvaderSpawner.SpawnPointList.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    void AddMe()
    {
        InvaderSpawner.SpawnPointList.Add(gameObject);
    }

    void NotValid()
    {
        if (GoodLocation == false)
            Destroy(gameObject);
    }
}