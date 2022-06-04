using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleWalk : MonoBehaviour
{
    int Wig = 1;

    public void Wiggle()
    {
        transform.Rotate(0, 0, 1*Wig, Space.Self);
        if (Mathf.Round(Mathf.Abs(gameObject.transform.localEulerAngles.z)) == 13 || Mathf.Round(Mathf.Abs(gameObject.transform.localEulerAngles.z)) == 348)
        {
            Wig = Wig * -1;
        }
    }
}
