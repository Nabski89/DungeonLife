using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScionTargetButton : MonoBehaviour
{
   public float DisableTimer;
    // Start is called before the first frame update
    void Update()
    {
        DisableTimer -= Time.deltaTime;
        if (DisableTimer < 0)
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void PRESSEDABUTTON()
    {

    }
}
