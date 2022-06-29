using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerShopUpgrade : MonoBehaviour
{
    public int MobCountMaxMod = 0;
    //positive removes this many seconds
    public float SpawnIntervalSecondsMod = 0;

    public int HPMod = 0;
    public int AtkMod = 0;
    public int DefMod = 0;
    void Start()
    {
        Spawner Spawner = gameObject.GetComponentInParent(typeof(Spawner)) as Spawner;
        Combat CombatController = Spawner.SpawnedMob.GetComponent<Combat>();

        Spawner.MobCountMax += MobCountMaxMod;
        Spawner.SpawnIntervalSeconds -= SpawnIntervalSecondsMod;

        //effects of what we are spawning
        CombatController.hp += HPMod;
        CombatController.MaxHp += HPMod;

        CombatController.Atk += AtkMod;
        CombatController.Def += DefMod;
    }
}
