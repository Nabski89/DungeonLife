using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int Atk = 6;
    public int AtkMod = 0;
    public int Damage = 1;

    public GameObject Splat;


    SpriteRenderer m_SpriteRenderer;
    public Sprite[] spriteList;

    int ResetTimer = 0;
    public int TrapDelay = 10;


    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.sprite = spriteList[0];
    }

    // Update is called once per frame
    void Update()
    {
        ResetTimer += 1;
        if (ResetTimer == TrapDelay * 30)
        {
            m_SpriteRenderer.sprite = spriteList[1];
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        DelverController controller = other.GetComponent<DelverController>();
        if (controller != null)
        {
            if (Random.Range(0, Atk) + AtkMod > Random.Range(0, controller.Def) + controller.DefMod && ResetTimer > TrapDelay * 30)
            {
                controller.hp -= Damage;
                controller.MoveIdle = TrapDelay * -30;


                Vector3 SplatSpot = controller.transform.position;
                SplatSpot.y += 1;
                Instantiate(Splat, SplatSpot, Quaternion.identity);

                m_SpriteRenderer.sprite = spriteList[0];
                ResetTimer = 0;
            }
        }
    }

}
