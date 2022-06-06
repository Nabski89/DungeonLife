using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour
{
    public KeyCode PushIt = KeyCode.Alpha1;
    public Button ThisButton;
    // Start is called before the first frame update
    void Start()
    {
        ThisButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(PushIt))
        {
 //           ThisButton.OnClick;
        }
    }
}
