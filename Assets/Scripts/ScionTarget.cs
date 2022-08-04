using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScionTarget : MonoBehaviour
{
    public GameObject Scion;
    public GameObject Button;
    GameObject Button1;
    GameObject Button2;



    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = Scion.GetComponent<SpriteRenderer>().sprite;
        Button1 = Instantiate(Button, transform.position + Vector3.right * 64, Quaternion.identity, transform);
        Button1.GetComponent<ScionTargetButton>().ButtonNum = 1;
        Button1.SetActive(false);
        Button2 = Instantiate(Button, transform.position + Vector3.right * 128, Quaternion.identity, transform);
        Button2.SetActive(false);
        Button2.GetComponent<ScionTargetButton>().ButtonNum = 2;
    }

    public void Push()
    {
        foreach (var Camera in GameObject.FindObjectsOfType<CameraController>())
        {
            Camera.transform.position = new Vector3(Scion.transform.position.x, Scion.transform.position.y, Camera.transform.position.z);
        }

        Button1.SetActive(true);
        Button1.GetComponent<ScionTargetButton>().DisableTimer = 10;
        Button2.SetActive(true);
        Button2.GetComponent<ScionTargetButton>().DisableTimer = 10;

        Button1.GetComponent<ScionTargetButton>().Targeter.SetActive(true);
        Button2.GetComponent<ScionTargetButton>().Targeter.SetActive(true);
    }
}