using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderNest : MonoBehaviour
{

    public GameObject[] InvaderSpawn;
    int SpawnNumber;
    float TimeToSpawn = 10;
    float TimeToSpawnDefault = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeToSpawn -= 1 * Time.deltaTime;
        if (TimeToSpawn < 0)
        {
            Spawn();
            TimeToSpawn = TimeToSpawnDefault;
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        //Make a new room on hitting the area game object
        Invader Invader = other.GetComponent<Invader>();
        if (Invader != null && SpawnNumber == 0)
        {
            //     Debug.Log("Spawn A Room");
            SpawnNumber = Invader.Number;
            Destroy(other.gameObject);
            Spawn();
        }
    }
    void Spawn()
    {
        if (SpawnNumber > 0)
        {
            GameObject SpawnedInvader = Instantiate(InvaderSpawn[SpawnNumber - 1], transform.position, Quaternion.identity, transform);
        }
    }
}
