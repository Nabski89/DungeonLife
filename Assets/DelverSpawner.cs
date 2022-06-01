using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelverSpawner : MonoBehaviour
{
    public GameObject DelverPrefab;

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < 1)
        {



            var type = Random.Range(0, 3);

            GameObject DelverSpawned = (GameObject)Instantiate(DelverPrefab, transform.position, Quaternion.identity, transform);
            DelverSpawned.GetComponent<DelverController>().ClassType = type;

            if (type == 0)
            {

                DelverSpawned.GetComponent<Combat>().MaxHp = DelverSpawned.GetComponent<Combat>().MaxHp + DelverSpawned.GetComponent<Combat>().MaxHp / 2;
                DelverSpawned.GetComponent<Combat>().hp = DelverSpawned.GetComponent<Combat>().hp + DelverSpawned.GetComponent<Combat>().hp/2;
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