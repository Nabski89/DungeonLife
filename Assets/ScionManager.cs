using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        GameObject NewButton = Instantiate(ScionUI, transform);
        NewButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, transform.childCount * -50);
        NewButton.GetComponent<ScionTarget>().Scion = NewLad;
    }
}