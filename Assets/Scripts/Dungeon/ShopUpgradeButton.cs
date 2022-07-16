using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUpgradeButton : MonoBehaviour
{
    float TimeToDie = 10;
    public float Cost = 10;
    public GameObject UpgradePrefab;
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
        GameObject NewSpawn = Instantiate(UpgradePrefab, transform.parent);
        Destroy(gameObject);
    }
}