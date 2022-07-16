using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    float TimeToDie = 10;
    public float Cost = 10;
    public GameObject Upgrade;
    public GameObject SpawnerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
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
        Vector3 Position = transform.position;
        Position.x = Mathf.Round(Position.x / 3) * 3 - 1;
        Position.y = Mathf.Round(Position.y / 3) * 3 - 1;
        GameObject NewSpawn = Instantiate(SpawnerPrefab, Position + Vector3.forward, Quaternion.identity);
        NewSpawn.GetComponent<Spawner>().SpawnedMob = Upgrade;


        GameObject Pappy = transform.parent.gameObject;
        //        transform.parent = null;
        Destroy(Pappy);
        //   Destroy(transform.parent.gameObject);
    }
}
