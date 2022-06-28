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
        Upgrades.Add(AddedThis);
    }
}
