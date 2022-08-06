using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpawns : MonoBehaviour
{
    //this is a duplicate of UIUpgrades
    public static UISpawns Instance;
    public GameObject BLANK;
    public GameObject Star;
    GameObject Baby;
    public static Image m_Graphic;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        Baby = transform.GetChild(0).gameObject;
    }


    public static void ShowUpgrades()
    {
        foreach (Transform child in Instance.transform.GetChild(0))
        {
            Destroy(child.gameObject);
        }
        int Amount = UpgradeHolder.SpawnList.Count;
        int i = 0;
        while (i < Amount)
        {
            //spawn a button to buy the upgrade, set the image and name
            GameObject UpSpawn = Instantiate(Instance.BLANK, Instance.transform.position + Vector3.left * 64 * (i + 1), Instance.transform.rotation, Instance.transform.GetChild(0));
            m_Graphic = UpSpawn.GetComponent<Image>();
            m_Graphic.sprite = UpgradeHolder.SpawnList[i].GetComponent<SpriteRenderer>().sprite;
            UpSpawn.name = UpgradeHolder.SpawnList[i].name;

            Combat Spawned = UpgradeHolder.SpawnList[i].GetComponent<Combat>();
            //if you change this change it in UIUpgrades as well
            if (Spawned != null)
            {
                //j is negative 1 here because it's a different script than upgrades
                int j = 0;
             //   Debug.Log("make star?????");
                while (j < Spawned.Tier)
                {
                    Instantiate(Instance.Star, UpSpawn.transform.position + Vector3.left * (26) + Vector3.up * (j * 12 + -26), UpSpawn.transform.rotation, UpSpawn.transform);
                    j++;
                }
            }
            i++;
        }
    }
    //This could also be done with transform.GetChild(0) type stuff, it's just a button to toggle upgrades
    public void ToggleActive()
    {
        if (Baby.activeSelf == true)
        {
            Baby.SetActive(false);
        }
        else
        {
            Baby.SetActive(true);
        }
        ShowUpgrades();
    }
}