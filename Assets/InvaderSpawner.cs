using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderSpawner : MonoBehaviour
{
    public float Timer;
    public float TimeBetweenSpawns = 10;
    public GameObject Invader1;

    public static float XMin = 6;
    public static float XMax = 6;
    public static float YMin = 6;
    public static float YMax = 6;
    public static int DungeonSize = 0;

    // Start is called before the first frame update
    void Awake()
    {
        XMin = 6;
        XMax = 6;
        YMin = 6;
        YMax = 6;
        DungeonSize = 0;
    }


    // Update is called once per frame
    public static void GrowDungeon(Vector3 RoomLocation)
    {
        XMin = Mathf.Min(XMin, Mathf.RoundToInt(RoomLocation.x));
        XMax = Mathf.Max(XMax, Mathf.RoundToInt(RoomLocation.x));
        YMin = Mathf.Min(YMin, Mathf.RoundToInt(RoomLocation.y));
        YMax = Mathf.Max(YMax, Mathf.RoundToInt(RoomLocation.y));
        DungeonSize += 1;
        Debug.Log("X: " + XMin + " to " + XMax + "     Y: " + YMin + " to " + YMax);
    }
    void Update()
    {
        Timer -= Time.deltaTime * DungeonSize;
        if (Timer < 0)
        {
            Timer = TimeBetweenSpawns;
            Spawn();
        }
    }

    void Spawn()
    {
        Debug.Log("Hello: " + gameObject.name);
        Vector3 SpawnLocation = new Vector3(Random.Range(XMin - 1, XMax + 2), Random.Range(YMin - 1, YMax + 2), 0);
        Debug.Log(SpawnLocation);
        Instantiate(Invader1, SpawnLocation, transform.rotation, transform);
    }
}