using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelverController : MonoBehaviour
{
    public int Level = 0;
    public int ClassXP = 0;
    public int JobXP = 0;
    int path = 8;
    int treasurepath = 8;
    public int MoveIdle = 0;
    public int MoveDelay = 10;

    public float treasure = 0;
    bool treasureFind = false;
    public WiggleWalk Body;

    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponentInChildren(typeof(WiggleWalk)) as WiggleWalk;
    }

    // Update is called once per frame
    void Update()
    {
        {
            MoveIdle += 1;
            if (MoveIdle <= 15 && MoveIdle >= 0)
            {
                move();
            }
            if (MoveIdle == 15 + MoveDelay && MoveIdle >= 0)
            {
                MoveIdle = 0;
            }
        }
        if (hp <= 0)
        {
            die();
        }
    }

    bool FindAPath = false;
    //raycasts want to be in fixed update. We are using this as our door check.
    void FixedUpdate()
    {
        //makes it so we only hit layer 7
        int layerMask = 1 << 7;
        //these are the debug lines so we can see what we are hitting.
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 2, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * 2, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.right) * 2, Color.white);

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 4, Color.blue);
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * 4, Color.blue);
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.right) * 4, Color.blue);

        //only fire when you're hit a room center
        if (FindAPath == true)
        {

            Debug.Log("Look for a route");
            path = 0;

            //Left (Lowest Priority after turn back)
            RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.right), 2, layerMask);
            // if it doesn't hit anything
            if (hitLeft.collider != null)
            {
                // Debug.Log("Left Hits " + hitLeft.collider.gameObject.name);
            }
            if (hitLeft.collider == null)
            {
                Debug.Log("Left Is Empty");
                path = 1;
            }

            //forward
            RaycastHit2D hitDown = Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector3.up), 2, layerMask);
            // if it doesn't hit anything
            if (hitDown.collider != null)
            {
                Debug.Log("Foward Hits " + hitDown.collider.gameObject.name);
            }
            if (hitDown.collider == null)
            {
                //            Debug.Log("Forward Is Empty");
                path = 2;
            }

            // Cast a ray straight To the characters right.
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector3.right), 2, layerMask);
            // If it hits something...
            if (hit.collider != null)
            {
                //            Debug.Log("Right(White) Hits " + hit.collider.gameObject.name);
            }
            if (hit.collider == null)
            {
                Debug.Log("Right(White) Is Empty");
                path = 3;
            }


            //Then we look for treasure


            RaycastHit2D TreasurehitLeft = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.right), 4, layerMask);
            if (TreasurehitLeft.collider != null && TreasurehitLeft.collider.gameObject.name == "Chest")
            {
                Debug.Log("TreasureSearch Hits " + TreasurehitLeft.collider.gameObject.name);
                treasureFind = true;
                treasurepath = 1;
            }

            //forward
            RaycastHit2D TreasurehitDown = Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector3.up), 4, layerMask);
            if (TreasurehitDown.collider != null && TreasurehitDown.collider.gameObject.name == "Chest")
            {
                Debug.Log("TreasureSearch Hits " + TreasurehitDown.collider.gameObject.name);
                treasureFind = true;
                treasurepath = 2;
            }

            // right.
            RaycastHit2D Treasurehit = Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector3.right), 4, layerMask);
            if (Treasurehit.collider != null && Treasurehit.collider.gameObject.name == "Chest")
            {
                Debug.Log("TreasureSearch) Hits " + Treasurehit.collider.gameObject.name);
                treasureFind = true;
                treasurepath = 3;
            }

            // if we didn't find treasure
            if (treasureFind == false)
            {
                if (path == 0) { TurnRight(); TurnRight(); }
                if (path == 1) { TurnLeft(); }
                if (path == 3) { TurnRight(); }
            }

            // if we did
            if (treasureFind == true)
            {
                Debug.Log("We turn a second time");
                if (treasurepath == 0) { TurnRight(); TurnRight(); }
                if (treasurepath == 1) { TurnLeft(); }
                if (treasurepath == 3) { TurnRight(); }
            }

            // Reset our variables
            treasureFind = false;
            FindAPath = false;
        }
    }
    public Vector3 thePosition;
    public Vector3 MoveFoward;
    void move()
    {
        Vector3 position = transform.position;

        if (MoveIdle <= 5)//move twice early to give a stuttery step? Why? I don't know, because I like it
        {
            position = transform.TransformPoint(Vector3.down * .02f);
            Body.Wiggle();
        }
        position = transform.TransformPoint(Vector3.down * .02f);
        Body.Wiggle();

        transform.position = position;
    }
    //this is just so we can call it from the door checker
    public void TurnRight()
    {
        transform.Rotate(0, 0, -90, Space.Self);
    }
    public void TurnLeft()
    {
        transform.Rotate(0, 0, 90, Space.Self);

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        DirectionTile controller = other.GetComponent<DirectionTile>();
        if (controller != null)
        {
            FindAPath = true;
            transform.position = controller.transform.position;
        }
    }

    void die()
    {
        float ManaValue = Level + ClassXP + JobXP;
        //      ManaController.mana += ManaValue;
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