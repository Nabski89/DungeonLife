using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerButton : MonoBehaviour
{
    float TimeToDie = 10;
    public float Cost = 10;
    public GameObject Upgrade;
    public GameObject SpawnerPrefab;
    public int SlotNum;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    //The shop only stays open for so long
    void Update()
    {
        TimeToDie -= 1 * Time.deltaTime;

        if (TimeToDie < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown() 
    {
        ManaController.Spend(Cost);
        //create a spawner in the bottom left of the room
        Vector3 Position = transform.position;
        Position.x = Mathf.Round(Position.x / 3) * 3 - 1;
        Position.y = Mathf.Round(Position.y / 3) * 3 - 1;
        GameObject NewSpawn = Instantiate(SpawnerPrefab, Position + Vector3.forward, Quaternion.identity);
        NewSpawn.GetComponent<Spawner>().SpawnedMob = Upgrade;


        GameObject Pappy = transform.parent.gameObject;
        //        transform.parent = null;

        //this removes it from the upgrade list
        UpgradeHolder.RemoveFromSpawnList(SlotNum);
        Destroy(Pappy);
        //   Destroy(transform.parent.gameObject);
    }
}
