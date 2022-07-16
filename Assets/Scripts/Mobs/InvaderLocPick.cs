using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderLocPick : MonoBehaviour
{
    MovementController MoveScript;
    Vector3 CurrentLoc;
    // Start is called before the first frame update
    float Timer = 3;

    int layerMask = 1 << 6;
    void Start()
    {
        MoveScript = GetComponent<MovementController>();

    }

    void FixedUpdate()
    {
        Timer -= 1 * Time.deltaTime;
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * 2, Color.red);
        if (Timer < 0)
        {
            RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector3.up), 3, layerMask);
            if (hitLeft.collider == null)
                TurnRight();
            if (hitLeft.collider != null)
            {
                MoveScript.enabled = true;
                Destroy(this);
            }
        }
    }


    public void TurnRight()
    {
        transform.Rotate(0, 0, -90, Space.Self);
    }
    public void TurnLeft()
    {
        transform.Rotate(0, 0, 90, Space.Self);
    }
    public void TurnLeftRANDOM()
    {
        if (Random.value < 0.5f)
            transform.Rotate(0, 0, 90, Space.Self);
    }
    public void TurnRightRANDOM()
    {
        if (Random.value < 0.5f)
            transform.Rotate(0, 0, -90, Space.Self);
    }
}
