using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerShopUpgrade : MonoBehaviour
{
    public int Tier = 1;
    public int MobCountMaxMod = 0;
    //positive removes this many seconds
    public float SpawnIntervalSecondsMod = 0;

    public int HPMod = 0;
    public int AtkMod = 0;
    public int DefMod = 0;
    void Start()
    {
        Spawner Spawner = gameObject.GetComponentInParent(typeof(Spawner)) as Spawner;
        if (Spawner != null)
        {

            Combat CombatController = Spawner.SpawnedMob.GetComponent<Combat>();

            Spawner.MobCountMax += MobCountMaxMod * Tier;
            Spawner.SpawnIntervalSeconds -= SpawnIntervalSecondsMod * Tier;

            //effects of what we are spawning
            CombatController.hp += HPMod * Tier;
            CombatController.MaxHp += HPMod * Tier;

            CombatController.Atk += AtkMod * Tier;
            CombatController.Def += DefMod * Tier;
        }
    }
}
