using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderSpawner : MonoBehaviour
{
    public float Timer;
    public float TimeBetweenSpawns = 1;
    public GameObject Invader;

    public static List<GameObject> SpawnPointList = new List<GameObject>();

    //doing this as an int keeps the dungeon safe for the first few rooms but makes it taper harder
    public static float DungeonSize = 0;
    void Awake()
    {
        SpawnPointList.Clear();
        DungeonSize = 0;
    }
    void Update()
    {
        //minus two is to account for the core and the one other room you must have
        Timer -= Mathf.Max(Time.deltaTime * ((DungeonSize - 1) / 3), 0);
        if (Timer < 0)
        {
            Timer = TimeBetweenSpawns;
            Spawn();
        }
    }

    void Spawn()
    {
        Instantiate(Invader, SpawnPointList[Random.Range(0, SpawnPointList.Count)].transform.position, transform.rotation, transform);
        Debug.Log("There are currently this many spawn points: " + SpawnPointList.Count);
    }
}