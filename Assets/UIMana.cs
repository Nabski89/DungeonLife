using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMana : MonoBehaviour
{
    public static UIMana Instance;
    void Start()
    {
        Instance = this;
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = ManaController.mana.ToString("0") + " Ѩ";
    }
    public void ManaUIUpdate()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "↑" + ManaController.ManaGain.ToString("0") + "↑\n" + ManaController.mana.ToString("0") + " Ѩ\n↓" + ManaController.ManaSpend.ToString("0") + "↓";
    }
}
