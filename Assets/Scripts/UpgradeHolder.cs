using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHolder : MonoBehaviour
{
    public static List<GameObject> SpawnList = new List<GameObject>();
    public static List<GameObject> Upgrades = new List<GameObject>();

    public static UpgradeHolder Instance;

    void Awake()
    {
        Instance = this;
    }
    public static void AddToSpawnList(GameObject AddedThis)
    {
        int SpawnListLength = SpawnList.Count;
        SpawnList.RemoveAll(u => u.name == AddedThis.name);

        if (SpawnList.Count - SpawnListLength == 0)
        {
            SpawnList.Add(AddedThis);
            DestroyChildren();
            UISpawns.ShowUpgrades();
        }
        if (SpawnList.Count - SpawnListLength == -1)
        {
            SpawnList.Add(AddedThis);
            SpawnList.Add(AddedThis);
            DestroyChildren();
            UISpawns.ShowUpgrades();
        }
        if (SpawnList.Count - SpawnListLength == -2)
        {
            GameObject StarSpawn = Instantiate(AddedThis, Instance.transform);
            StarSpawn.name += "*";
            StarSpawn.GetComponent<Combat>().Tier += 1;
            Debug.Log(AddedThis + " Was Upgraded");
            AddToSpawnList(StarSpawn);
        }
    }
    public static void AddToUpgradeList(GameObject AddedThis)
    {
        int UpgradeLength = Upgrades.Count;
        Upgrades.RemoveAll(u => u.name == AddedThis.name);

        if (Upgrades.Count - UpgradeLength == 0)
        {
            Upgrades.Add(AddedThis);
            DestroyChildren();
            UIUpgrades.ShowUpgrades();
        }
        if (Upgrades.Count - UpgradeLength == -1)
        {
            Upgrades.Add(AddedThis);
            Upgrades.Add(AddedThis);
            DestroyChildren();
            UIUpgrades.ShowUpgrades();
        }
        if (Upgrades.Count - UpgradeLength == -2)
        {
            GameObject StarUpgrade = Instantiate(AddedThis, Instance.transform);
            StarUpgrade.name += "*";
            StarUpgrade.GetComponent<SpawnerShopUpgrade>().Tier += 1;
            Debug.Log(AddedThis + " Was Upgraded");
            AddToUpgradeList(StarUpgrade);
        }
    }

    public static void RemoveFromSpawnList(int RemoveThis)
    {
        SpawnList.RemoveAt(RemoveThis);
        UISpawns.ShowUpgrades();
    }

    public static void RemoveFromUpgradeList(int RemoveThis)
    {
        Upgrades.RemoveAt(RemoveThis);
        UIUpgrades.ShowUpgrades();
    }

    // I should clean this up every now and then, but I have absolutely no idea when it is safe to do so in the mean time I'm just letting them pile up
    public static void DestroyChildren()
    {
        foreach (Transform child in Instance.transform)
        {
            // GameObject.Destroy(child.gameObject);
        }
    }
}
