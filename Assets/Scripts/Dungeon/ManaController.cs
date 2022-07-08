using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaController : MonoBehaviour
{
    public static ManaController Instance;
    public static float mana = 100;
    public static float ManaSpend = 0;
    public static float ManaGain = 0;
    public float ManaDisplayOnly = 0;
    Vector3 myVector;

    void Awake()
    {
        mana = 100;
        ManaSpend = 0;
        ManaGain = 0;
        myVector = new Vector3(1, 1, 1);
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        mana += .1f * Time.deltaTime;
        if (ManaSpend > 0)
        {
            //square root so that the more you're in debt the faster it goes
            mana -= (1f + Mathf.Sqrt(ManaSpend)) * Time.deltaTime;
            ManaSpend -= (1f * Mathf.Sqrt(ManaSpend)) * Time.deltaTime;

            //a game over screen
            if (mana < 0)
                SceneBoss.GameOverScene();

        }
        if (ManaGain > 0)
        {
            mana += (1f + Mathf.Sqrt(ManaGain)) * Time.deltaTime;
            ManaGain -= (1f + Mathf.Sqrt(ManaGain)) * Time.deltaTime;
        }
        // this is just so I can see how much mana we have
        transform.localScale = 2.5f * myVector * (Mathf.Pow((mana/*/ 100*/) / (4 * 3.14f), .3333f));

        Vector3 newRotation = new Vector3(-90, mana * 10, 0);
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
            if (Delver.treasureReq > Delver.treasure)
            {
                ManaSpend += Delver.treasureReq - Delver.treasure;
                Delver.treasure += Delver.treasureReq - Delver.treasure;
            }
        }
    }


    public static void Spend(float BLING)
    {
        ManaSpend += BLING;
        UIMana.Instance.ManaUIUpdate();
    }

    public static void Gain(float CACHING)
    {
        ManaGain += CACHING;
        UIMana.Instance.ManaUIUpdate();
    }
}