using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaController : MonoBehaviour
{
    public static float mana = 100;
    public float ManaDisplayOnly = 0;
    Vector3 myVector;


    void Awake()
    {
        myVector = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        mana += 0.16f * Time.deltaTime;

        // this is just so I can see how much mana we have
        transform.localScale = myVector * (1.5f * Mathf.Pow((mana / 100) / (4 * 3.14f), .3333f));

        Vector3 newRotation = new Vector3(0, mana, 0);
        transform.eulerAngles = newRotation;

        if (mana.ToString("0") != ManaDisplayOnly.ToString("0"))
        {
            ManaDisplayOnly = mana;
            UIMana.Instance.ManaUIUpdate();
        }

    }
    public void OnTriggerStay2D(Collider2D other)
    {
        DelverController Delver = other.GetComponent<DelverController>();
        if (Delver != null)
        {
            if (Delver.treasureReq > Delver.treasure && mana > 10)
            {
                Delver.InCombat = true;
                mana -= 1 * Time.deltaTime;
                Delver.treasure += 1 * Time.deltaTime;
            }
            if (Delver.treasureReq < Delver.treasure && mana > 10)
                Delver.InCombat = false;
        }
    }
}
