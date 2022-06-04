using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    public Sprite[] spriteList;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spriteList[Random.Range(0, spriteList.Length)];
        //spin the floor tile
        transform.Rotate(0, 0, Random.Range(0, 4) * 90, Space.Self);

    }

}
