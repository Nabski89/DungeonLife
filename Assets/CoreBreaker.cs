using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreBreaker : MonoBehaviour
{
    public float Damage = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var step = 1 * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, ManaController.Instance.transform.position, step);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        DoorBlocker Door = other.GetComponent<DoorBlocker>();
        ManaController Core = other.GetComponent<ManaController>();
        if (Door != null)
        {
            Debug.Log("We Hit A Door");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (Core != null)
        {
            ManaController.Spend(Damage);
            Destroy(gameObject);
        }
    }
}
