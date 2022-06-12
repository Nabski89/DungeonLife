using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderSpawner : MonoBehaviour
{
    public float Timer;
    public float TimeBetweenSpawns = 100;
    public GameObject Invader1;

    public static List<GameObject> SpawnPointList = new List<GameObject>();

    public static int DungeonSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        DungeonSize = 0;
    }

    void Update()
    {
        Timer -= Time.deltaTime * (DungeonSize/3);
        if (Timer < 0)
        {
            Timer = TimeBetweenSpawns;
            Spawn();
        }
    }

    void Spawn()
    {
        Instantiate(Invader1, SpawnPointList[Random.Range(0, SpawnPointList.Count)].transform.position, transform.rotation, transform);
        Debug.Log("There are currently " + SpawnPointList.Count);
    }
}