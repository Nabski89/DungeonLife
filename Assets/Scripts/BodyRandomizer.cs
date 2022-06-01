using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRandomizer : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    public Sprite[] spriteList;
    public bool RandColor = false;

    //Defaults are only redish colors
    public float redmin = 0.1f;
    public float redmax = .9f;
    public float greenmin = 0.01f;
    public float greenmax = .25f;
    public float bluemin = 0.01f;
    public float bluemax = .1f;


    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.sprite = spriteList[Random.Range(0, spriteList.Length)];

        if (RandColor == true)
        {
            m_SpriteRenderer.color = new Color(Random.Range(redmin, redmax), Random.Range(greenmin, greenmax), Random.Range(bluemin, bluemax));
        }

        DelverController DelverParent = GetComponentInParent<DelverController>();
        if (DelverParent != null)
        {
            m_SpriteRenderer.sprite = spriteList[DelverParent.ClassType];
        }
    }
}
