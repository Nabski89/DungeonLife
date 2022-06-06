using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour
{
    //public GameObject ALittleSquareThatIsTheMap;
    public GameObject Rooms;
    //GameObject RoomCenter;

    public bool valid = false;
    public int cost = 10;
    float TextDelay = 5;

    public GameObject Text;
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
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
                Rooms.SetActive(true);
                ManaController.Spend(cost);
                //this tracks our dungeon size and costs and dimensions
                Debug.Log(transform.position);
                InvaderSpawner.GrowDungeon(transform.position);

                foreach (var NextRooms in GameObject.FindObjectsOfType<Expand>())
                {
                    if (Vector3.Distance(NextRooms.transform.position, transform.position) < 4)
                        NextRooms.valid = true;
                }
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
        DirectionTile controller = other.GetComponent<DirectionTile>();
        if (controller != null)
        {
            Destroy(gameObject);
        }
    }
}