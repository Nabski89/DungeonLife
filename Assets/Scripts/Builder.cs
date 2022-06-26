using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{


    public int Cost = 5;
    public float UnGrowTimer = 0;
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

        MOBS
        FARM    -1/-1, gives more rewards on death
        SWARM   -1 hp -1/-1, Spawntime/2, higher spawn cap
        NORMAL  +0/+0
        STRONG  +1/+1
    */
    public GameObject SpawnerPrefab;
    public GameObject LEFT;
    public GameObject RIGHT;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left ctrl"))
        {
            grow();
            UnGrowTimer = 5;
        }
        if (Input.GetKey("left ctrl"))
        {
            UnGrowTimer += 1 * Time.deltaTime;
        }

        UnGrowTimer -= 1 * Time.deltaTime;
        if (UnGrowTimer <= 0)
        {
            ungrow();
        }
    }

    void OnMouseDown()
    {
        if (transform.childCount < 1)
        {

            UnGrowTimer = 10;
            Vector3 LeftPosition = transform.TransformPoint(Vector3.left);
            Vector3 RightPosition = transform.TransformPoint(Vector3.right);
            int RandCount = UpgradeHolder.Defenders.Count;
            int rand1 = Random.Range(0, RandCount);
            int rand2 = Random.Range(0, RandCount);

            Debug.Log(UpgradeHolder.Defenders.Count + " upgrades and you rolled " + rand1 + " and " + rand2);

            Debug.Log(UpgradeHolder.Defenders[rand1]);

            // spawn the purchaser, then set the cost, sprite, and what it will actually spawn if purchased, which is a pass down twice thing
            LEFT = Instantiate(SpawnerPrefab, LeftPosition, transform.rotation, transform);
            LEFT.GetComponent<UpgradeButton>().Cost = UpgradeHolder.Defenders[rand1].GetComponent<CostManager>().Cost;
            LEFT.GetComponent<SpriteRenderer>().sprite = UpgradeHolder.Defenders[rand1].GetComponent<SpriteRenderer>().sprite;
            LEFT.GetComponent<UpgradeButton>().Upgrade = UpgradeHolder.Defenders[rand1];
            if (RandCount > 1)
            {
                while (rand1 == rand2)
                {
                    rand2 = Random.Range(0, RandCount);
                }
                RIGHT = Instantiate(SpawnerPrefab, RightPosition, transform.rotation, transform);
                RIGHT.GetComponent<UpgradeButton>().Cost = UpgradeHolder.Defenders[rand2].GetComponent<CostManager>().Cost;
                RIGHT.GetComponent<SpriteRenderer>().sprite = UpgradeHolder.Defenders[rand2].GetComponent<SpriteRenderer>().sprite;
                RIGHT.GetComponent<UpgradeButton>().Upgrade = UpgradeHolder.Defenders[rand2];
            }
        }
    }
    //if the core is there, you can't build
    public void OnTriggerEnter2D(Collider2D other)
    {
        ManaController controller = other.GetComponent<ManaController>();
        if (controller != null)
            Destroy(gameObject);

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
