using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public int Faction = 1;
    MovementController MovementScript;
    Defender DefenderScript;
    Combat EnemyScript;

    //COMBAT STUFF BELOW

    public int MaxHp = 10;
    public int hp = 10;
    public int Atk = 6;
    public int AtkMod = 1;
    public int Def = 6;
    public int DefMod = 1;
    public int Damage = 1;

    // The splats
    public GameObject Splat;
    public GameObject AtkSplatGO;
    public GameObject DefSplatGO;


    // Start is called before the first frame update
    void Start()
    {
        //get our main body
        MovementScript = GetComponent<MovementController>();
        DefenderScript = GetComponent<Defender>();

        if (DefenderScript != null)
        {
            timer -= 2.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
            Destroy(gameObject);
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        EnemyScript = other.GetComponent<Combat>();
        //    if (Faction != EnemyScript.Faction)
        {
            if (EnemyScript != null)
            {
                if (EnemyScript.Faction != Faction)
                {
                    if (MovementScript != null)
                        MovementScript.InCombat = false;
                    if (DefenderScript != null)
                        DefenderScript.InCombat = false;
                }
            }
        }
    }
    float timer = 0.0f;
    int AtkCooldownTime = 4;
    public void OnTriggerStay2D(Collider2D other)
    {
        EnemyScript = other.GetComponent<Combat>();
        if (EnemyScript != null)
            if (EnemyScript.Faction != Faction)
            {
                {
                    timer += Time.deltaTime;

                    if (timer > AtkCooldownTime)
                    {
                        timer = 0;
                        Attack();
                    }
                    if (MovementScript != null)
                    {
                        MovementScript.InCombat = true;
                    }
                    if (DefenderScript != null)
                    {
                        DefenderScript.InCombat = true;
                    }
                }
            }
    }
    public void Attack()
    {

        //store our attack/defense rolls so we can display them later
        int AtkRoll = Random.Range(0, Atk) + AtkMod;
        int DefRoll = Random.Range(0, EnemyScript.Def) + EnemyScript.DefMod;

        // check if we hit
        if (AtkRoll > DefRoll)
        {
            EnemyScript.hp -= Damage;
            Vector3 SplatSpot = EnemyScript.transform.position;
            SplatSpot.y += 0.5f;
            GameObject HPSplat = (GameObject)Instantiate(Splat, SplatSpot, Quaternion.identity);
            HPSplat.GetComponent<TMPro.TextMeshPro>().text = Damage.ToString();
            HPSplat.GetComponent<Splat>().timer = (AtkCooldownTime / 2);
        }

        //Get our positioning
        Vector3 AtkSpot = transform.position;
        if (transform.position.x > EnemyScript.transform.position.x)
            AtkSpot.x += 0.75f;
        else
            AtkSpot.x -= 0.75f;
        if (transform.position.y > EnemyScript.transform.position.y)
            AtkSpot.y += 0.75f;
        else
            AtkSpot.y -= 0.75f;

        AtkSpot.y += 0.25f;
        AtkSpot.x -= 0.25f;

        Vector3 DefSpot = AtkSpot;
        DefSpot.y -= 0.5f;
        DefSpot.x += 0.5f;

        //spawn them

        GameObject AtkSplat = (GameObject)Instantiate(AtkSplatGO, AtkSpot, Quaternion.identity);
        AtkSplat.GetComponent<TMPro.TextMeshPro>().text = AtkRoll.ToString();
        AtkSplat.GetComponent<Splat>().timer = (AtkCooldownTime / 2);

        GameObject DefSplat = (GameObject)Instantiate(DefSplatGO, DefSpot, Quaternion.identity);
        DefSplat.GetComponent<TMPro.TextMeshPro>().text = DefRoll.ToString();
        DefSplat.GetComponent<Splat>().timer = (AtkCooldownTime / 2);
    }

    void OnMouseDown()
    {
        UICombat.Instance.CombatUpdate(hp, Atk, AtkMod, Def, DefMod, Damage);
    }
}