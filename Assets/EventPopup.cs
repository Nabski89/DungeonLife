using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPopup : MonoBehaviour
{
    public float Speed = 1;


    public void Unpause()
    {
        Debug.Log("Completed Event");
        Time.timeScale = Speed;
        Destroy(gameObject);
    }
}
