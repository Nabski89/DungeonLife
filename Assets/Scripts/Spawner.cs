using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float cooldown = 0;
    public int MobCountMax = 3;
    public float SpawnIntervalSeconds = 5;

    public GameObject SpawnedMob;

    SpriteRenderer m_SpriteRenderer;
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.sprite = SpawnedMob.GetComponent<SpriteRenderer>().sprite;
        Defender Spawn = GetComponentInChildren(typeof(Defender)) as Defender;
        if (Spawn != null)
        {
            MobCountMax += Spawn.MobCount;
            SpawnIntervalSeconds = Spawn.SpawnRate * SpawnIntervalSeconds;
        }

    }

    void Update()
    {
        cooldown += Time.deltaTime;
        if (cooldown > SpawnIntervalSeconds)
        {

            if (transform.childCount < MobCountMax)
            {
                cooldown = 0;

                Instantiate(SpawnedMob, transform.position + Vector3.back, Quaternion.identity, transform);
                //                Debug.Log(SpawnedMob.Length);
                //       Instantiate(SpawnedMob[Random.Range(0, SpawnedMob.Length)], transform.position+Vector3.back, Quaternion.identity, transform);
            }
        }
    }
}
