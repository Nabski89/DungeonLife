using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int cooldown = 0;
    public int MobCountMax = 3;
    public int SpawnIntervalSeconds = 5;

    public GameObject[] SpawnedMob;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        cooldown += 1;
        if (cooldown > SpawnIntervalSeconds * 30)
        {

            if (transform.childCount < MobCountMax)
            {
                cooldown = 0;
                Debug.Log(SpawnedMob.Length);
                Instantiate(SpawnedMob[Random.Range(0, SpawnedMob.Length)], new Vector3(transform.position.x, transform.position.y, -0.1f), Quaternion.identity, transform);
            }
        }
    }
}
