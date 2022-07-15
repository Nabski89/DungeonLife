using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScionTarget : MonoBehaviour
{
    public GameObject Scion;
    public GameObject Button;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Button1 = Instantiate(Button, transform);

        GameObject Button2 = Instantiate(Button, transform);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
