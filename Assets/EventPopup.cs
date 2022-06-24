using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPopup : MonoBehaviour
{
    public float Speed = 1;
    public TMPro.TextMeshProUGUI MainText;
    public TMPro.TextMeshProUGUI Text1;
    public TMPro.TextMeshProUGUI Text2;
    public TMPro.TextMeshProUGUI Text3;

    public void GainMana(int Amount)
    {
        ManaController.Gain(Amount);
    }

    public void Unpause()
    {
        Time.timeScale = Speed;
        Destroy(gameObject);
    }
}
