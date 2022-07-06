using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileParent : MonoBehaviour
{
    public string AreaTypo;
    public int Ranwood = 1;
    public int ReadyToPassRoomType = 0;
    //Awake is before start
    // Start is called before the first frame update
    void Awake()
    {
        Ranwood = Random.Range(0, 4);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Area Area = other.GetComponent<Area>();

        if (Area != null)
        {
            ReadyToPassRoomType = 1;
            AreaTypo = Area.AreaType;
            Debug.Log(ReadyToPassRoomType);
            //       Debug.Log("time to spawn a tile");
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(this, 1);
        }
        //spin the floor tile
        //  transform.Rotate(0, 0, Random.Range(0, 4) * 90, Space.Self);
    }
    //spin the floor tile
    //  transform.Rotate(0, 0, Random.Range(0, 4) * 90, Space.Self);
}