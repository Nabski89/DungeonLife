using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float cooldown = 0;
    public int MobCountMax = 3;
    public float SpawnIntervalSeconds = 5;

    public GameObject SpawnedMob;
    public GameObject SpawnerPrefab;
    public int UpgradesBought = 0;

    SpriteRenderer m_SpriteRenderer;

    public GameObject LeftUpgrade;
    public GameObject MidUpgrade;
    public GameObject RightUpgrade;
    bool ShopActive;

    // these are used in the SpawnIt sub
    public int HPMod = 0;
    public int AtkMod = 0;
    public int DefMod = 0;
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

    public float UnGrowTimer = 0;
    void Update()
    {
        if (transform.childCount < MobCountMax + 3)
        {
            cooldown += Time.deltaTime;
            if (cooldown > SpawnIntervalSeconds)
            {
                cooldown = 0;
                SpawnIn();

                //                Debug.Log(SpawnedMob.Length);
                //       Instantiate(SpawnedMob[Random.Range(0, SpawnedMob.Length)], transform.position+Vector3.back, Quaternion.identity, transform);
            }
        }


        if (Input.GetKeyDown("left ctrl"))
        {
            grow();
            UnGrowTimer = 5;
        }
        if (Input.GetKey("left ctrl"))
        {
            UnGrowTimer += 1 * Time.deltaTime;
        }

        UnGrowTimer -= 1 * Time.deltaTime;
        if (UnGrowTimer <= 0)
        {
            ungrow();
        }
    }
    void SpawnIn()
    {
        GameObject SpawnIt = Instantiate(SpawnedMob, transform.position + Vector3.back, Quaternion.identity, transform);

        Combat CombatController = SpawnIt.GetComponent<Combat>();
        //effects of what we are spawning
        CombatController.hp += HPMod;
        CombatController.MaxHp += HPMod;

        CombatController.Atk += AtkMod;
        CombatController.Def += DefMod;
    }


    void grow()
    {
        if (UpgradesBought < 3)
        {
            m_SpriteRenderer.color = Color.red;
            ShopActive = true;
        }
    }
    void ungrow()
    {
        m_SpriteRenderer.color = Color.black;
        ShopActive = false;
    }

    void OnMouseDown()
    {
        if (ShopActive == true)
        {
            UnGrowTimer = 10;

            int RandCount = UpgradeHolder.Upgrades.Count;
            int rand1 = Random.Range(0, RandCount);
            int rand2 = Random.Range(0, RandCount);
            int rand3 = Random.Range(0, RandCount);

            Debug.Log(UpgradeHolder.Upgrades.Count + " upgrades avaliable");
            // spawn the purchaser, then set the cost, sprite, and what it will actually spawn if purchased, which is a pass down twice thing

            if (UpgradesBought < 1 && LeftUpgrade.transform.childCount < 1)
            {
                Vector3 UpPosition = transform.TransformPoint(Vector3.up * 2);
                GameObject LEFT = Instantiate(SpawnerPrefab, UpPosition, transform.rotation, LeftUpgrade.transform);

                CreateShopButton(LEFT, rand1, 1);
            }

            if (RandCount > 3 && UpgradesBought < 2 && MidUpgrade.transform.childCount < 1)
            {

                while (rand1 == rand2)
                {
                    rand2 = Random.Range(0, RandCount);
                }
                Vector3 UpRightPosition = transform.TransformPoint(Vector3.up * 2 + Vector3.right * 2);
                GameObject MID = Instantiate(SpawnerPrefab, UpRightPosition, transform.rotation, MidUpgrade.transform);
                CreateShopButton(MID, rand2, 2);
            }

            if (RandCount > 5 && RightUpgrade.transform.childCount < 1)
            {
                while (rand3 == rand2 || rand3 == rand1)
                {
                    rand3 = Random.Range(0, RandCount);
                }
                Vector3 RightPosition = transform.TransformPoint(Vector3.right * 2);
                GameObject RIGHT = Instantiate(SpawnerPrefab, RightPosition, transform.rotation, RightUpgrade.transform);
                CreateShopButton(RIGHT, rand3, 4);
            }
        }
    }
    //spawn a clickable prefab with the icon of what you'll actuall create, with the cost varying based on location
    void CreateShopButton(GameObject Object, int Rand, float PriceMod)
    {
        ShopUpgradeButton UpgradeScript = Object.GetComponent<ShopUpgradeButton>();
        Debug.Log(UpgradeScript);

        UpgradeScript.UpgradePrefab = UpgradeHolder.Upgrades[Rand];
        UpgradeScript.Cost = UpgradeHolder.Upgrades[Rand].GetComponent<CostManager>().Cost * PriceMod;

        Object.GetComponent<SpriteRenderer>().sprite = UpgradeHolder.Upgrades[Rand].GetComponent<SpriteRenderer>().sprite;
    }
}
