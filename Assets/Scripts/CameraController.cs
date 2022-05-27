using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //if I was smarter I would auto assign this
    public Camera TheCamera;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        if (Input.GetKey("left"))
        {
            position = transform.TransformPoint(Vector3.left * .2f);
            transform.position = position;
        }
        if (Input.GetKey("up"))
        {
            position = transform.TransformPoint(Vector3.up * .2f);
            transform.position = position;
        }
        if (Input.GetKey("right"))
        {
            position = transform.TransformPoint(Vector3.right * .2f);
            transform.position = position;
        }
        if (Input.GetKey("down"))
        {
            position = transform.TransformPoint(Vector3.down * .2f);
            transform.position = position;
        }

//zoom
        if (Input.GetKeyDown("page up"))
        {
            TheCamera.orthographicSize  += 1.5f;
        }
        if (Input.GetKeyDown("page down") && TheCamera.orthographicSize > 3)
        {
            TheCamera.orthographicSize  -= 1.5f;
        }

//speed
        if (Input.GetKeyDown(KeyCode.Home))
        {
Application.targetFrameRate += 15;
        }
        if (Input.GetKeyDown(KeyCode.End) && Application.targetFrameRate > 0)
        {
Application.targetFrameRate -= 15;
        }

    }        
}
