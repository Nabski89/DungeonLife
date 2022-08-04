using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHolder : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite[] Wood1;
    public Sprite[] Wood2;
    public Sprite[] Wood3;
    public Sprite[] Wood4;
    public Sprite[] Grass1;
    public Sprite[] Cave1;
    public static TileHolder Instance;
    void Awake()
    {
        Instance = this;

    }
}
