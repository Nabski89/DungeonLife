using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject DOOR1;
    public GameObject DOOR2;
    public GameObject SoundEffect1;

    SpriteRenderer m_SpriteRenderer;
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = Color.blue;
            }
    void OnMouseDown()
    {
        ManaController.Spend(5);
        DoorTrigger();
    }

    public void DoorTrigger()
    {
        if (DOOR1.activeSelf == true)
        {
            DOOR1.SetActive(false);
            DOOR2.SetActive(false);
            //hoho we can just make the game object of a sound and then destroy it? Big brain or stupid I don't know or care right now I've been at this most of the afternoon.
            GameObject SoundEffect = (GameObject)Instantiate(SoundEffect1, transform.position, Quaternion.identity);
            Destroy(SoundEffect, 5);
            m_SpriteRenderer.color = Color.green;
        }
        else
        {
            DOOR1.SetActive(true);
            DOOR2.SetActive(true);
            GameObject SoundEffect = (GameObject)Instantiate(SoundEffect1, transform.position, Quaternion.identity);
            Destroy(SoundEffect, 5);
            Debug.Log("DOOR");
            m_SpriteRenderer.color = Color.blue;
        }

    }
}
