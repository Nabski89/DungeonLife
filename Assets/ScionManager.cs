using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScionManager : MonoBehaviour
{
    public GameObject ScionUI;
    public static ScionManager Instance;

    void Awake()
    {
        Instance = this;
    }
    public void AddScion(GameObject NewLad)
    {
        Spawn(ScionUI);
    }

    void Spawn(GameObject MiniEventSpawned)
    {
        GameObject NewButton = Instantiate(MiniEventSpawned, transform);
        NewButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, transform.childCount * -50);
    }
}