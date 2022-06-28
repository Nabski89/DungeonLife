using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderSpawner : MonoBehaviour
{
    public float Timer;
    public float TimeBetweenSpawns = 1;
    public GameObject Invader1;

    public static List<GameObject> SpawnPointList = new List<GameObject>();

    //doing this as an int keeps the dungeon safe for the first few rooms but makes it taper harder
    public static float DungeonSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        DungeonSize = 0;
    }

    void Update()
    {
        Timer -= Mathf.Max(Time.deltaTime * ((DungeonSize - 2) / 3), 0);
        if (Timer < 0)
        {
            Timer = TimeBetweenSpawns;
            Spawn();
        }
    }

    void Spawn()
    {
        Instantiate(Invader1, SpawnPointList[Random.Range(0, SpawnPointList.Count)].transform.position, transform.rotation, transform);
        Debug.Log("There are currently this man spawn points: " + SpawnPointList.Count);
    }
}