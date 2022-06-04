using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour
{
    //public GameObject ALittleSquareThatIsTheMap;
    public GameObject Rooms;
    //GameObject RoomCenter;

    public int cost = 10;
    float TextDelay = 5;

    public GameObject Text;

    void OnMouseDown()
    {
        //activate the text, get the ability to edit it, display the cost, then if you click it while text is up you buy it
        if (Text.activeSelf == false)
        {
            Text.SetActive(true);
            Text.GetComponent<TMPro.TextMeshPro>().text = cost + " Ѩ";
            TextDelay = 5;
        }
        else
        {
            Rooms.SetActive(true);
            ManaController.ManaSpend += cost;
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (ManaController.ManaSpend > 0)
        {
            if (GetComponent<BoxCollider2D>().enabled == true)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                Text.SetActive(false);
                TextDelay = 0;
            }
        }
        if (ManaController.ManaSpend < 0)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }

        if (Text.activeSelf == true && TextDelay < 0)
        {
            TextDelay -= 1 * Time.deltaTime;
            if (TextDelay < 0)
                Text.SetActive(false);
        }
    }
}
