using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPopup : MonoBehaviour
{



public void GainMana(int Amount)
{
    ManaController.Gain(Amount);
}
}
