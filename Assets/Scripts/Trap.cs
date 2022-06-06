using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int Atk = 6;
    public int AtkMod = 0;
    public int Damage = 1;

    public GameObject Splat;
    public GameObject AtkSplatGO;
    public GameObject DefSplatGO;
    SpriteRenderer m_SpriteRenderer;
    public Sprite[] spriteList;

    float ResetTimer = 0;
    public int TrapDelay = 8 + 3; //This is long enough to explore a T and come back and get snapped again


    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.sprite = spriteList[0];
    }

    // Update is called once per frame
    void Update()
    {
        ResetTimer += 1 * Time.deltaTime;
        if (ResetTimer > TrapDelay)
        {
            m_SpriteRenderer.sprite = spriteList[1];
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        DelverController controller = other.GetComponent<DelverController>();
        if (controller != null)
        {
            int AtkRoll = Random.Range(0, Atk) + AtkMod;
            int DefRoll = Random.Range(0, controller.Def);
            if (AtkRoll > DefRoll + controller.DefMod && ResetTimer > TrapDelay * 30)
            {
                controller.hp -= Damage;
                //it takes 3 seconds to move between rooms
                controller.MoveIdle = 3;


                Vector3 SplatSpot = controller.transform.position;
                SplatSpot.y += 1;
                GameObject HPSplat = (GameObject)Instantiate(Splat, SplatSpot, Quaternion.identity);
                HPSplat.GetComponent<TMPro.TextMeshPro>().text = Damage.ToString();
                Destroy(HPSplat, 5);

                Vector3 AtkSpot = controller.transform.position;
                AtkSpot.y -= 1;
                GameObject AtkSplat = (GameObject)Instantiate(AtkSplatGO, AtkSpot, Quaternion.identity);
                AtkSplat.GetComponent<TMPro.TextMeshPro>().text = AtkRoll.ToString();
                Destroy(AtkSplat, 5);


                AtkSpot.x += 1;
                GameObject DefSplat = (GameObject)Instantiate(DefSplatGO, AtkSpot, Quaternion.identity);
                DefSplat.GetComponent<TMPro.TextMeshPro>().text = DefRoll.ToString();
                Destroy(DefSplat, 5);


                m_SpriteRenderer.sprite = spriteList[0];
                ResetTimer = 0;
            }
        }
    }

}
