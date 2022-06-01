using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float cooldown = 0;
    public int MobCountMax = 3;
    public int SpawnIntervalSeconds = 5;

    public GameObject[] SpawnedMob;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        cooldown += Time.deltaTime;
        if (cooldown > SpawnIntervalSeconds)
        {

            if (transform.childCount < MobCountMax)
            {
                cooldown = 0;
                Debug.Log(SpawnedMob.Length);
                Instantiate(SpawnedMob[Random.Range(0, SpawnedMob.Length)], transform.position, Quaternion.identity, transform);
            }
        }
    }
}
