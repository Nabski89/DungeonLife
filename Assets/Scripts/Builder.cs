using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public GameObject[] BuildingCoreOptions;
    public int UnGrowTimer = 0;
    /* note to self, to prevent gameplay from getting stale maybe have this always give you 2 out of 5 upgrade options, esp at the start
     base upgrades would be

     treasure (money)
        /       \
     Money      Gear
                /\
                Weapon/Defense

     "Empty Room"
        /       \
     Trap       Rest

        Research
        /       \
    Upgrades    Capacity
            mob(normal)
            mob(magic)
            mob(armored)

            all mobs go
            /      \
        stronger    more
    */
    public GameObject LEFT;
    public GameObject RIGHT;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left ctrl"))
        {
            grow();
            UnGrowTimer = 30 * 5;
        }
        if (Input.GetKey("left ctrl"))
        {
            UnGrowTimer += 1;
        }

        UnGrowTimer -= 1;
        if (UnGrowTimer == 0)
        {
            ungrow();
        }
    }

    void OnMouseDown()
    {
        UnGrowTimer = 30 * 10;
        Vector3 LeftPosition = transform.TransformPoint(Vector3.left);
        Vector3 RightPosition = transform.TransformPoint(Vector3.right);

        int rand1 = Random.Range(0, BuildingCoreOptions.Length);
        int rand2 = Random.Range(0, BuildingCoreOptions.Length);
        Instantiate(BuildingCoreOptions[rand1], LeftPosition, transform.rotation, transform);
        while (rand1 == rand2)
        {
            rand2 = Random.Range(0, BuildingCoreOptions.Length);
        }
        Instantiate(BuildingCoreOptions[rand2], RightPosition, transform.rotation, transform);
    }

    void grow()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
    void ungrow()
    {
        transform.localScale = new Vector3(1, 1, 1) * 0.0005f;
    }


}