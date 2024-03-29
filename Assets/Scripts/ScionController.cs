using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScionController : MonoBehaviour
{
    public bool InCombat = false;
    public Vector3 TargetPosition1;
    Vector3 TrueTargetPosition1;
    public Vector3 TargetPosition2;
    Vector3 TrueTargetPosition2;
    public bool Forward = false;
    public GameObject ScionChildren;
    public float InitialSpeed = 1;
    float speed = 1;
    public int XP;
    public int Level;


    Combat CombatScript;

    // Start is called before the first frame update
    void Start()
    {
        CombatScript = GetComponent<Combat>();
        transform.position = ManaController.Instance.transform.position;
        foreach (var Manager in GameObject.FindObjectsOfType<ScionManager>())
            Manager.AddScion(transform.gameObject);
        TargetPosition1 = ManaController.Instance.transform.position + Vector3.up + Vector3.right;
        TargetPosition2 = ManaController.Instance.transform.position - Vector3.up - Vector3.right;
        TrueTargetPosition1 = TargetPosition1;
        TrueTargetPosition2 = TargetPosition2;

        speed = InitialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (InCombat == false)
        {
            var step = 1 * speed * Time.deltaTime; // calculate distance to move

            if (Forward == true)
            {
                if (transform.position.x == TrueTargetPosition1.x)
                    transform.position = Vector3.MoveTowards(transform.position, TrueTargetPosition1, step);
                else
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(TrueTargetPosition1.x, transform.position.y, transform.position.z), step);
            }
            else
            {
                if (transform.position.y == TrueTargetPosition2.y)
                    transform.position = Vector3.MoveTowards(transform.position, TrueTargetPosition2, step);
                else
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, TrueTargetPosition2.y, transform.position.z), step);
            }
            if (transform.position == TrueTargetPosition1)
            {
                Forward = false;
                TrueTargetPosition1 = TargetPosition1;
            }
            if (transform.position == TrueTargetPosition2)
            {
                Forward = true;
                TrueTargetPosition2 = TargetPosition2;
            }
        }
    }
    public void Die()
    {
        Debug.Log("A scion has died");
        transform.position = transform.position = ManaController.Instance.transform.position;
        ManaController.Spend(XP);
        CombatScript.Atk -= Level;
        CombatScript.Def -= Level;
        Level = 0;
        XP = 0;
        CombatScript.hp = CombatScript.MaxHp;
    }

    public void Kill(int XPgain)
    {
        ManaController.Gain(XPgain);
        XP += XPgain;
        if (XP > 50 * (Level * Level + (Level - 2)))
        {
            Level += 1;
            CombatScript.Atk += 1;
            CombatScript.Def += 1;
            UpgradeHolder.AddToSpawnList(ScionChildren);
            Debug.Log("Level " + Level);
        }
        CombatScript.hp += 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DoorBlocker Door = other.GetComponent<DoorBlocker>();
        if (Door != null)
        {
            speed = InitialSpeed * 0.25f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        DoorBlocker Door = other.GetComponent<DoorBlocker>();
        if (Door != null)
        {
            speed = InitialSpeed;
        }
    }
}
