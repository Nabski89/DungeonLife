using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    Combat CombatScript;
    public int Loot = 1;
    public int Number = 0;
    // Start is called before the first frame update
    void Start()
    {
        CombatScript = GetComponent<Combat>();
        InvaderSpawner.InvaderTier = Mathf.Max(InvaderSpawner.InvaderTier, Number);
        //       Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (CombatScript.hp <= 0)
        {
            ManaController.ManaGain += Loot;
            Destroy(gameObject);
        }
    }
    void OnMouseDown()
    {
        if (Input.GetKeyDown("left ctrl")) { }
    }
}
