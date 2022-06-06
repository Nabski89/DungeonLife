using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//still needs to be moved from frame based to time based
public class DelverController : MonoBehaviour
{
    public int Level = 0;
    public int ClassXP = 0;
    public int JobXP = 0;

    public float MoveIdle = 0;
    //use these stat to affect character speed

    public float treasure = 0;
    public float treasureReq = 10;

    //Used by the body to pick your pants
    public int ClassType;


    // Start is called before the first frame update
    void Start()
    {

    }


    //raycasts want to be in fixed update. We are using this as our door check.
    void FixedUpdate()
    {
        if (hp <= 0)
        {
            die();
        }
    }
    void die()
    {
        float ManaValue = Level + ClassXP + JobXP;
        //      ManaController.Spend += ManaValue;
        Destroy(gameObject);
    }





    //COMBAT STUFF BELOW

    public int MaxHp = 10;
    public int hp = 10;
    public int Atk = 6;
    public int AtkMod = 1;
    public int Def = 6;
    public int DefMod = 1;



}

/*       Vector2 position = transform.position;


        if (MoveDir == 5)//still
        {
            position.x += 0;
        }
        if (MoveDir == 8)//north
        {
            position.y += 0.05f;
        }
        if (MoveDir == 6)//east
        {
            position.x += 0.05f;
        }
        if (MoveDir == 2)//south
        {
            position.y -= 0.05f;
        }
        if (MoveDir == 4)//west
        {
            position.x -= 0.05f;
        }
        transform.position = position;
        


        //race car action
        if (Input.GetKey("left"))
        {
            transform.Rotate(00.0f, 00.0f, 01.0f, Space.Self);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(00.0f, 00.0f, -01.0f, Space.Self);
        }

                //this spawns things to the right of the object
                thePosition = transform.TransformPoint(Vector3.left * 2);
                Instantiate(someObject, thePosition, someObject.transform.rotation);
        */