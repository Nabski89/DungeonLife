using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int cooldown = 0;
    public int MobCountMax = 3;

    public GameObject[] SpawnedMob;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cooldown +=1;
        if (cooldown > 5 * 30)
        {
            cooldown = 0;
            var SpawnCount = GetComponentsInChildren<Defender>();
            if (SpawnCount.Length < MobCountMax)
            {
                Instantiate(SpawnedMob[Random.Range(0, SpawnedMob.Length)], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity, transform);
            }
        }
    }
}
