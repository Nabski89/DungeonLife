using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScionController : MonoBehaviour
{
    public bool InCombat = false;
    public Vector3 TargetPosition1;
    public Vector3 TargetPosition2;
    public bool Forward = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var Manager in GameObject.FindObjectsOfType<ScionManager>())
            Manager.AddScion(transform.gameObject);
        TargetPosition1 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (InCombat == false)
        {
            var step = 1 * Time.deltaTime; // calculate distance to move

            if (Forward == true)
            {
                if (transform.position.x == TargetPosition1.x)
                    transform.position = Vector3.MoveTowards(transform.position, TargetPosition1, step);
                else
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(TargetPosition1.x, transform.position.y, transform.position.z), step);
            }
            else
            {
                if (transform.position.y == TargetPosition2.y)
                    transform.position = Vector3.MoveTowards(transform.position, TargetPosition2, step);
                else
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, TargetPosition2.y, transform.position.z), step);
            }
            if (transform.position == TargetPosition1)
                Forward = false;
            if (transform.position == TargetPosition2)
                Forward = true;
        }
    }
}
