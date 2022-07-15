using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    TileParent Source;
    // Start is called before the first frame update


    void Start()
    {
        Source = GetComponentInParent(typeof(TileParent)) as TileParent;
        {
      //      Debug.Log("time to spawn a tile");
            if (Source.AreaTypo == "wood")
            {
        //        Debug.Log("wood type");
                if (Source.Ranwood == 0)
                    GetComponent<SpriteRenderer>().sprite = TileHolder.Instance.Wood1[Random.Range(0, TileHolder.Instance.Wood1.Length)];
                if (Source.Ranwood == 1)
                    GetComponent<SpriteRenderer>().sprite = TileHolder.Instance.Wood2[Random.Range(0, TileHolder.Instance.Wood2.Length)];
                if (Source.Ranwood == 2)
                    GetComponent<SpriteRenderer>().sprite = TileHolder.Instance.Wood3[Random.Range(0, TileHolder.Instance.Wood3.Length)];
                if (Source.Ranwood == 3)
                    GetComponent<SpriteRenderer>().sprite = TileHolder.Instance.Wood4[Random.Range(0, TileHolder.Instance.Wood4.Length)];
            }
            if (Source.AreaTypo == "grass")
                GetComponent<SpriteRenderer>().sprite = TileHolder.Instance.Grass1[Random.Range(0, TileHolder.Instance.Grass1.Length)];
            if (Source.AreaTypo == "cave")
                GetComponent<SpriteRenderer>().sprite = TileHolder.Instance.Cave1[Random.Range(0, TileHolder.Instance.Cave1.Length)];
            Destroy(this, 1);
        }
        //spin the floor tile
        //  transform.Rotate(0, 0, Random.Range(0, 4) * 90, Space.Self);
    }
}