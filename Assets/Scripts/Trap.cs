using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int Damage = 1;

    public GameObject Splat;
    SpriteRenderer m_SpriteRenderer;
    public Sprite[] spriteList;

    float ResetTimer = 0;
    public int TrapDelay = 8 + 3; //This is long enough to explore a T and come back and get snapped again


    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.position + Vector3.one + Vector3.back;
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
            if (ResetTimer > TrapDelay)
            {
                controller.hp -= Damage;

                Vector3 SplatSpot = controller.transform.position;
                SplatSpot.y += 1;
                GameObject HPSplat = (GameObject)Instantiate(Splat, SplatSpot, Quaternion.identity);
                HPSplat.GetComponent<TMPro.TextMeshPro>().text = Damage.ToString();
                Destroy(HPSplat, 5);

                m_SpriteRenderer.sprite = spriteList[0];
                ResetTimer = 0;
            }
        }
    }

}
