using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splat : MonoBehaviour
{
    public float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
    //        Debug.Log("Destroy Splat");
            Destroy(gameObject);
        }
    }
}
