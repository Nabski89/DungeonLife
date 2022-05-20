using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleWalk : MonoBehaviour
{
    int Wig = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Wiggle()
    {
        transform.Rotate(0, 0, 1*Wig, Space.Self);
        if (Mathf.Round(Mathf.Abs(gameObject.transform.localEulerAngles.z)) == 10 || Mathf.Round(Mathf.Abs(gameObject.transform.localEulerAngles.z)) == 350)
        {
            Wig = Wig * -1;
        }
    }
}
