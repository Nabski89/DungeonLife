using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelverSpawner : MonoBehaviour
{
    public GameObject DelverPrefab;
    public GameObject NotEnoughTreasureGun;
    public int Tier = 0;
    float timer;
    float cooldown = 30;
    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (transform.childCount < 5 && timer > cooldown)
        {
            timer = 0;
            var type = Random.Range(0, 3);

            GameObject DelverSpawned = (GameObject)Instantiate(DelverPrefab, transform.position + Vector3.down, Quaternion.identity, transform);
            DelverSpawned.GetComponent<Combat>().Tier += Tier;
            DelverSpawned.GetComponent<DelverController>().ClassType = type;

            if (type == 0)
            {

                DelverSpawned.GetComponent<Combat>().MaxHp = DelverSpawned.GetComponent<Combat>().MaxHp + DelverSpawned.GetComponent<Combat>().MaxHp / 2;
                DelverSpawned.GetComponent<Combat>().hp = DelverSpawned.GetComponent<Combat>().hp + DelverSpawned.GetComponent<Combat>().hp / 2;
            }
            if (type == 1)
            {
                DelverSpawned.GetComponent<Combat>().Def += 2;
            }
            if (type == 2)
            {
                DelverSpawned.GetComponent<Combat>().Atk += 2;
            }
        }
    }
    //congrats it is time to leave the dungeon!
    public void OnTriggerEnter2D(Collider2D other)
    {
        DelverController Delver = other.GetComponent<DelverController>();
        if (Delver != null)
        {
            if (Delver.treasureReq > Delver.treasure)
            {
                //Spawn the fuck you gun if we didn't get enough treasure
                GameObject TreasureGun = (GameObject)Instantiate(NotEnoughTreasureGun, transform.position + Vector3.down, Quaternion.identity, transform);
                TreasureGun.GetComponent<CoreBreaker>().Damage = (Delver.treasureReq - Delver.treasure) * 4;
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }





    //Healer

    //Melee
    //Barbarian     0
    //Fighter
    //Rogue

    //Caster - Starts with an element
    //Wizard
    //Sorceror
    //Warlock

    //Maybe Someday we get healing in here
    //Monk
    //Cleric
    //Paladin






}