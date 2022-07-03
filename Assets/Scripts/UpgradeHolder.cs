using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHolder : MonoBehaviour
{
    public static List<GameObject> Defenders = new List<GameObject>();
    public static List<GameObject> Upgrades = new List<GameObject>();

    public static UpgradeHolder Instance;

    void Awake()
    {
        Instance = this;
    }
    public static void AddToSpawnList(GameObject AddedThis)
    {
        Defenders.Add(AddedThis);
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


    // I should clean this up every now and then, but I have absolutely no idea when it is safe to do so in the mean time I'm just letting them pile up
    public static void DestroyChildren()
    {
        foreach (Transform child in Instance.transform)
        {
           // GameObject.Destroy(child.gameObject);
        }
    }
}
