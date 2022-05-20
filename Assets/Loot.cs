using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public float TreasureValue = 60;
    public float TreasureGrowthRate = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        this.name = "Chest";
    }
    void Update()
    {
        TreasureValue += TreasureGrowthRate;
    }
    // Update is called once per frame

    public void OnTriggerEnter2D(Collider2D other)
    {
        DelverController controller = other.GetComponent<DelverController>();
        if (controller != null)
        {
            controller.treasure += TreasureValue;
            ManaController.mana += TreasureValue / 2;
            controller.MoveIdle = Mathf.RoundToInt(-TreasureValue * 2);

            //make sure the chest doesn't instantly respawn
            Spawner Spawner = gameObject.GetComponentInParent(typeof(Spawner)) as Spawner;
            if (Spawner != null)
            {
                Spawner.cooldown = 0;
            }

            Destroy(gameObject);
        }
    }
}
