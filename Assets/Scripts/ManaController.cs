using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaController : MonoBehaviour
{
    public static float mana = 100;
    public float ManaDisplayOnly = 0;
    Vector3 myVector;

    // Start is called before the first frame update
    void Start()
    {
        myVector = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        mana += .01f;

// this is just so I can see how much mana we have
 ManaDisplayOnly = mana;

        transform.localScale = myVector * (1.5f * Mathf.Pow((mana / 100) / (4 * 3.14f), .3333f));

        Vector3 newRotation = new Vector3(0, mana, 0);
        transform.eulerAngles = newRotation;
    }

}
