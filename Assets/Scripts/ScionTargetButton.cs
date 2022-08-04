using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScionTargetButton : MonoBehaviour
{
    public float DisableTimer;
    public int ButtonNum = 0;
    bool Find = false;
    public GameObject TargeterPrefab;
    public GameObject Targeter;

    ScionController Scion;
    // Start is called before the first frame update

    void Awake()
    {
        Scion = transform.parent.GetComponent<ScionTarget>().Scion.GetComponent<ScionController>();
        Targeter = Instantiate(TargeterPrefab, transform.position+Vector3.forward, Quaternion.identity);
    }
    void Update()
    {
        DisableTimer -= Time.deltaTime;
        if (DisableTimer < 0)
        {
            Find = false;
            gameObject.SetActive(false);
            Targeter.SetActive(false);
        }
        // if left button pressed...
        if (Input.GetMouseButtonDown(0) && Find == true)
        {
            Vector3 ClickedHere = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ClickedHere = new Vector3(Mathf.Round(ClickedHere.x / 3) * 3, Mathf.Round(ClickedHere.y / 3) * 3, transform.position.z);

            if (ButtonNum == 1)
            {
                Scion.TargetPosition1 = ClickedHere;
                Destroy(Targeter);
                Targeter = Instantiate(TargeterPrefab, ClickedHere+Vector3.forward, Quaternion.identity);
            }
            // TargetPosition1;
            else
            {
                Scion.TargetPosition2 = ClickedHere;
                Destroy(Targeter);
                Targeter = Instantiate(TargeterPrefab, ClickedHere+Vector3.forward, Quaternion.identity);
            }
            Find = false;
        }
    }
    // Update is called once per frame
    // Update is called once per frame
    public void PRESSEDABUTTON()
    {
        Find = true;
    }
}
