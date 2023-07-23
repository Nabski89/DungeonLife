using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    public Vector3 MouseLocation;
    float MouseRotation;
    // Start is called before the first frame update
    void Start()
    {
        MouseLocation = Vector3.forward * 10;
    }

    // Update is called once per frame
    void Update()
    {
        MouseLocation.x = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x / 3) * 3;
        MouseLocation.y = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y / 3) * 3;
        transform.position = MouseLocation;

        MouseRotation += Input.mouseScrollDelta.y * 30;
        Quaternion target = Quaternion.Euler(0, 0, Mathf.Round(MouseRotation / 90) * 90);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5);
        
    }
}
