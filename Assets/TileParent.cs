using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileParent : MonoBehaviour
{
    public string AreaTypo;
    public int Ranwood = 1;
    public GameObject DirTile;
    public GameObject FloorTile;
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
            AreaTypo = Area.AreaType;
            //       Debug.Log("time to spawn a tile");
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<BoxCollider2D>());

            Instantiate(DirTile, transform);
            SpawnTile(Vector3.down);
            SpawnTile(Vector3.up);

            SpawnTile(Vector3.right);
            SpawnTile(Vector3.down + Vector3.right);
            SpawnTile(Vector3.up + Vector3.right);

            SpawnTile(Vector3.left);
            SpawnTile(Vector3.down + Vector3.left);
            SpawnTile(Vector3.up + Vector3.left);

            Destroy(this);
        }
        //spin the floor tile
        //  transform.Rotate(0, 0, Random.Range(0, 4) * 90, Space.Self);
    }
    //spin the floor tile
    //  transform.Rotate(0, 0, Random.Range(0, 4) * 90, Space.Self);

    void SpawnTile(Vector3 Direction)
    {
        Instantiate(FloorTile, transform.position + Direction, Quaternion.identity, transform);
    }
}