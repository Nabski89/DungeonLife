using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //if I was smarter I would auto assign this
    public Camera TheCamera;
    public static float TimeHolder = 1;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        Time.timeScale = 1;

        InvaderEvent.EventCount = 0;
        DelverEvent.EventCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 position = transform.position;
        if (Input.GetKey("left") || mousePos.x < 20)
        {
            position = transform.TransformPoint(Vector3.left * .2f);
            transform.position = position;
        }
        if (Input.GetKey("up") || mousePos.y > Screen.height - 20)
        {
            position = transform.TransformPoint(Vector3.up * .2f);
            transform.position = position;
        }
        if (Input.GetKey("right") || mousePos.x > Screen.width - 20)
        {
            position = transform.TransformPoint(Vector3.right * .2f);
            transform.position = position;
        }
        if (Input.GetKey("down") || mousePos.y < 20)
        {
            position = transform.TransformPoint(Vector3.down * .2f);
            transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            transform.position = (Vector3.back * 10);
        }


        //zoom
        if (Input.GetKeyDown("page up"))
        {
            TheCamera.orthographicSize += 1.5f;
        }
        if (Input.GetKeyDown("page down") && TheCamera.orthographicSize > 3)
        {
            TheCamera.orthographicSize -= 1.5f;
        }

        //speed
        if (Input.GetKeyDown(KeyCode.Home) && Time.timeScale < 3.5 && Time.timeScale != 0)
        {
            //Time.timeScale = 2;
            Time.timeScale += 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.End) && Time.timeScale > 1)
        {

            Time.timeScale -= 0.5f;
            if (Time.timeScale < 1)
                Time.timeScale = 1;
        }

    }



    public void Pause()
    { TimeHolder = Time.timeScale; }

    public void UnPause()
    {
        Debug.Log("Unpause");
        Time.timeScale = Mathf.Max(1, TimeHolder);
    }
}
