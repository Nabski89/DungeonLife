using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickStart : MonoBehaviour
{
    public GameObject[] Upgrade;
    public GameObject[] Spawn;
    public GameObject[] TrapOrTreasure;
    // Start is called before the first frame update
    void Start()
    {
        UpgradeHolder.AddToSpawnList(Spawn[Random.Range(0, Spawn.Length)]);
        UpgradeHolder.AddToSpawnList(TrapOrTreasure[Random.Range(0, TrapOrTreasure.Length)]);

        UpgradeHolder.AddToUpgradeList(Upgrade[Random.Range(0, Upgrade.Length)]);
        Destroy(gameObject);
    }
}