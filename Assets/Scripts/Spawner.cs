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

    bool ShopActive;
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
            Vector3 UpPosition = transform.TransformPoint(Vector3.up * 2);
            Vector3 UpRightPosition = transform.TransformPoint(Vector3.up * 2 + Vector3.right * 2);
            Vector3 RightPosition = transform.TransformPoint(Vector3.right * 2);

            int RandCount = UpgradeHolder.Upgrades.Count;
            int rand1 = Random.Range(0, RandCount);
            int rand2 = Random.Range(0, RandCount);
            int rand3 = Random.Range(0, RandCount);

            Debug.Log(UpgradeHolder.Upgrades.Count + " upgrades avaliable");
            // spawn the purchaser, then set the cost, sprite, and what it will actually spawn if purchased, which is a pass down twice thing

            if (UpgradesBought < 1)
            {
                GameObject LEFT = Instantiate(SpawnerPrefab, UpPosition, transform.rotation, transform);
                LEFT.GetComponent<UpgradeButton>().Cost = UpgradeHolder.Upgrades[rand1].GetComponent<CostManager>().Cost;
                LEFT.GetComponent<SpriteRenderer>().sprite = UpgradeHolder.Upgrades[rand1].GetComponent<SpriteRenderer>().sprite;
                LEFT.GetComponent<UpgradeButton>().Upgrade = UpgradeHolder.Upgrades[rand1];
            }
            if (RandCount > 3 && UpgradesBought < 2)
            {

                while (rand1 == rand2)
                {
                    rand2 = Random.Range(0, RandCount);
                }
                GameObject UPRIGHT = Instantiate(SpawnerPrefab, UpRightPosition, transform.rotation, transform);
                UPRIGHT.GetComponent<UpgradeButton>().Cost = UpgradeHolder.Upgrades[rand2].GetComponent<CostManager>().Cost * 2;
                UPRIGHT.GetComponent<SpriteRenderer>().sprite = UpgradeHolder.Upgrades[rand2].GetComponent<SpriteRenderer>().sprite;
                UPRIGHT.GetComponent<UpgradeButton>().Upgrade = UpgradeHolder.Upgrades[rand2];
            }
            if (RandCount > 5)
            {

                while (rand3 == rand2 || rand3 == rand1)
                {
                    rand3 = Random.Range(0, RandCount);
                }
                GameObject RIGHT = Instantiate(SpawnerPrefab, RightPosition, transform.rotation, transform);
                RIGHT.GetComponent<UpgradeButton>().Cost = UpgradeHolder.Upgrades[rand3].GetComponent<CostManager>().Cost * 4;
                RIGHT.GetComponent<SpriteRenderer>().sprite = UpgradeHolder.Upgrades[rand3].GetComponent<SpriteRenderer>().sprite;
                RIGHT.GetComponent<UpgradeButton>().Upgrade = UpgradeHolder.Upgrades[rand3];
            }
        }
    }
}
