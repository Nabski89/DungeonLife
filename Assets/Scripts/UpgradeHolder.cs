using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHolder : MonoBehaviour
{
    public static List<GameObject> Defenders = new List<GameObject>();
    public static List<GameObject> Upgrades = new List<GameObject>();

    public static void AddToSpawnList(GameObject AddedThis)
    {
        Defenders.Add(AddedThis);
    }
    public static void AddToUpgradeList(GameObject AddedThis)
    {
        //     if (Upgrades.Contains AddedThis)
        Upgrades.Add(AddedThis);
        UIUpgrades.ShowUpgrades();
    }
}
