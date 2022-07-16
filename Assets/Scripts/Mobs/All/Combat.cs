using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public int Faction = 1;
    public int Tier = 0;

    MovementController MovementScript;

    Combat EnemyScript;
    ScionController ScionScript;
    Defender DefenderScript;
    DelverController DelverScript;
    Invader InvaderScript;

    bool Scion = false;
    bool Defender = false;
    bool Delver = false;
    bool Invader = false;


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

    public float DefManaGain = 0;
    public float AtkManaGain = 0;


    // Start is called before the first frame update
    void Start()
    {
        Atk += Tier;
        Def += Tier;
        MaxHp += Tier / 2;
        MaxHp += Tier / 2;
        //get our main body
        MovementScript = GetComponent<MovementController>();


        ScionScript = GetComponent<ScionController>();
        if (ScionScript != null)
        {
            Scion = true;
        }

        DefenderScript = GetComponent<Defender>();
        if (DefenderScript != null)
        {
            timer -= 0.5f;
            Defender = true;
        }

        DelverScript = GetComponent<DelverController>();
        if (DelverScript != null)
        {
            Delver = true;
        }

        InvaderScript = GetComponent<Invader>();
        if (InvaderScript != null)
        {
            Invader = true;
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
                    if (ScionScript != null)
                        ScionScript.InCombat = false;

                }
            }
        }
    }
    float timer = 0.0f;
    float AtkCooldownTime = 2;
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
                    if (ScionScript != null)
                    {
                        ScionScript.InCombat = true;
                    }
                }
            }
    }
    public void Attack()
    {

        //store our attack/defense rolls so we can display them later
        int AtkRoll = Random.Range(0, Atk) + AtkMod;
        int DefRoll = Random.Range(0, EnemyScript.Def) + EnemyScript.DefMod;

        //Gain mana based on how well rolls went
        //this should be a rare thing with most of our mana income coming from kills or work
        ManaController.Gain(AtkRoll * AtkManaGain);
        ManaController.Gain(EnemyScript.DefManaGain * DefRoll);

        // check if we hit
        if (AtkRoll > DefRoll)
        {
            EnemyScript.hp -= Damage;
            if (EnemyScript.hp < 1)
            {
                Kill();
            }
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
    void Kill()
    {
        int xp = EnemyScript.Def + EnemyScript.DefMod + EnemyScript.Atk + EnemyScript.AtkMod + 3 * EnemyScript.MaxHp + 5 * EnemyScript.Damage;
        if (Scion == true)
        {
            ScionScript.Kill(xp);
        }
        if (Delver == true)
        {

        }
    }
    void OnMouseDown()
    {
        UICombat.Instance.CombatUpdate(hp, Atk, AtkMod, Def, DefMod, Damage, this);
    }
}