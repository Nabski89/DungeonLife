using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTierUpgrade : MonoBehaviour
{
    Combat CombatController;
    public int tier = 1;

    public bool HPModB = false;
    public bool AtkModB = false;
    public bool DefModB = false;
    // Start is called before the first frame update
    void Start()
    {
        CombatController = GetComponent<Combat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HPModB == true)
        {
            CombatController.hp += tier;
            CombatController.MaxHp += tier;
        }
        if (AtkModB == true)
        {
            CombatController.Atk += tier * 2;
            if (tier == 4)
                CombatController.AtkMod += 1;
        }
        if (DefModB == true)
        {
            CombatController.Def += tier * 2;
            if (tier == 4)
                CombatController.DefMod += tier;
        }

    }
}
