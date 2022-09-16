using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBuilder : MonoBehaviour
{
    public GameObject Expand;

    public int xMin = 0;
    public int yMin = 0;
    public int xLimit = 100;
    public int yLimit = 100;    // Start is called before the first frame update
    void Start()
    {
        int xSpawn = xMin;
        int ySpawn = yMin;
        while (ySpawn < yLimit)
        {
            while (xSpawn < xLimit)
            {
                Instantiate(Expand, new Vector3(xSpawn, ySpawn, 0), Quaternion.identity, transform);
                xSpawn += 3;
                if (xSpawn > xLimit)

                    ySpawn += 3;
            }
            xSpawn = xMin;
        }
    }
}
