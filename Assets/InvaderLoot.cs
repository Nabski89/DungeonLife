using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderLoot : MonoBehaviour
{
    Combat CombatScript;
    public int Loot = 1;
    // Start is called before the first frame update
    void Start()
    {
        CombatScript = GetComponent<Combat>();
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
}
