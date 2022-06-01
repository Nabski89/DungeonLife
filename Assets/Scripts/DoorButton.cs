using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject DOOR;
    public GameObject SoundEffect1;

    void OnMouseDown()
    {
        if (ManaController.mana > 5)
        {
            if (DOOR.active)
            {
                DOOR.SetActive(false);
                //hoho we can just make the game object of a sound and then destroy it? Big brain or stupid I don't know or care right now I've been at this most of the afternoon.
                GameObject SoundEffect = (GameObject)Instantiate(SoundEffect1, transform.position, Quaternion.identity);
                Destroy(SoundEffect, 5);
            }
            else
            {
                DOOR.SetActive(true);
                GameObject SoundEffect = (GameObject)Instantiate(SoundEffect1, transform.position, Quaternion.identity);
                Destroy(SoundEffect, 5);
                Debug.Log("DOOR");
            }
            ManaController.mana -= 5;
            UIMana.Instance.ManaUIUpdate();
        }
    }
}
