using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICombat : MonoBehaviour
{
    public static UICombat Instance;
    // Start is called before the first frame update

    public TMPro.TextMeshProUGUI HPT;
    public TMPro.TextMeshProUGUI AtkT;
    public TMPro.TextMeshProUGUI DefT;
    public TMPro.TextMeshProUGUI DamageT;
    public Combat StatBoi;
    public GameObject StatsHolder;



    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        if (StatBoi != null)
        {
            HPT.text = StatBoi.hp.ToString("0") + " ♥";
            AtkT.text = StatBoi.Atk.ToString("0") + " + " + StatBoi.AtkMod.ToString("0");
            DefT.text = StatBoi.Def.ToString("0") + " + " + StatBoi.DefMod.ToString("0");
            DamageT.text = StatBoi.Damage.ToString("0") + " Damage";
        }
        if (StatBoi == null)
        {
            StatsHolder.SetActive(false);
        }

    }


    public void CombatUpdate(int hp, int Atk, int AtkMod, int Def, int DefMod, int Damage, Combat OurBoi)
    {
        StatsHolder.SetActive(true);
        HPT.text = hp.ToString("0") + " ♥";
        AtkT.text = Atk.ToString("0") + " + " + AtkMod.ToString("0");
        DefT.text = Def.ToString("0") + " + " + DefMod.ToString("0");
        DamageT.text = Damage.ToString("0") + " Damage";
        StatBoi = OurBoi;
    }
}
