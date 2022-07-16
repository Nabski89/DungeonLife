using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpawns : MonoBehaviour
{
    //this is a duplicate of UIUpgrades
    public static UISpawns Instance;
    public GameObject BLANK;
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
            GameObject UpSpawn = Instantiate(Instance.BLANK, Instance.transform.position + Vector3.left * 50 * (i + 1), Instance.transform.rotation, Instance.transform.GetChild(0));
            m_Graphic = UpSpawn.GetComponent<Image>();
            m_Graphic.sprite = UpgradeHolder.SpawnList[i].GetComponent<SpriteRenderer>().sprite;
            UpSpawn.name = UpgradeHolder.SpawnList[i].name;
            i++;
        }
    }
    //This could also be done with transform.GetChild(0) type stuff, it's jut a button to toggle upgrades
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
