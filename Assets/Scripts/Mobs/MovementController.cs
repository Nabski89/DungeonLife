using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//still needs to be moved from frame based to time based
public class MovementController : MonoBehaviour
{
    int path = 8;
    int treasurepath = 8;

    public float MoveIdle = 0;
    //use these stat to affect character speed
    public float MoveDelay = 0.3f;
    public float Speed = 1;
    public Vector3 TargetPosition;

    //true if they go after treasure
    public bool TreasureCare = false;

    bool treasureFind = false;
    public bool InCombat;
    int layerMask = 1 << 7;

    //Wigglewalk stuff
    public WiggleWalk Body;
    //    int Wig = 1;
    bool FindAPath = false;

    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponentInChildren(typeof(WiggleWalk)) as WiggleWalk;
        TargetPosition = transform.position;
    }


    //raycasts want to be in fixed update. We are using this as our door check.
    void FixedUpdate()
    {
        {
            if (MoveIdle >= 0)
                MoveIdle -= 1 * Time.deltaTime;
            if (MoveIdle <= 0 && InCombat == false)
            {
                var step = 1 * Time.deltaTime * Speed; // calculate distance to move

                if (Vector3.Distance(transform.position, TargetPosition) < 0.33f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, TargetPosition, step);
                }
                transform.position = Vector3.MoveTowards(transform.position, TargetPosition, step);

                //now we wiggle or we would if this code worked, don't forget to uncomment Body and Wig when trying to fix it.
                /*
                Body.transform.Rotate(0, 0, 30 * Time.deltaTime * Wig, Space.Self);
                if (Mathf.Round(Mathf.Abs(Body.transform.localEulerAngles.z)) == 13 || Mathf.Round(Mathf.Abs(Body.transform.localEulerAngles.z)) == 348)
                {
                    Wig = Wig * -1;
                }
                */
            }
            if (transform.position == TargetPosition)
            {
                if (MoveIdle >= 0)
                    MoveIdle = MoveDelay;
                GetTargetPosition();
            }
        }

        //makes it so we only hit layer 7

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

        //    Debug.Log("Look for a route");
            path = 0;

            //Left (Lowest Priority after turn back)
            ScanForPath(Vector3.right, 1);
            ScanForPath(-Vector3.up, 2);
            ScanForPath(-Vector3.right, 3);
            //Then we look for treasure
            if (TreasureCare == true)
            {
                ScanForTreasure(Vector3.right, 1);
                ScanForTreasure(-Vector3.up, 2);
                ScanForTreasure(-Vector3.right, 3);

                // if did find treasure
                if (treasureFind == true)
                {
                    if (treasurepath == 0) { TurnRight(); TurnRight(); }
                    if (treasurepath == 1) { TurnLeft(); }
                    if (treasurepath == 3) { TurnRight(); }
                    GetTargetPosition();
                }
            }
            // if we didn't find treasure
            if (treasureFind == false)
            {
                if (path == 0) { TurnRight(); TurnRight(); }
                if (path == 1) { TurnLeft(); }
                if (path == 3) { TurnRight(); }
                GetTargetPosition();
            }

            // Reset our variables
            treasureFind = false;
            FindAPath = false;
        }
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
    public void GetTargetPosition()
    {
        TargetPosition = transform.position + (transform.TransformDirection(Vector3.down));
        TargetPosition.x = Mathf.RoundToInt(TargetPosition.x);
        TargetPosition.y = Mathf.RoundToInt(TargetPosition.y);
    }
    public void ScanForPath(Vector3 Direction, int PathNum)
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, transform.TransformDirection(Direction), 2, layerMask);
        if (hitLeft.collider == null)
        {
            path = PathNum;
        }
    }

    public void ScanForTreasure(Vector3 Direction, int PathNum)
    {
        RaycastHit2D Treasurehit = Physics2D.Raycast(transform.position, transform.TransformDirection(Direction), 4, layerMask);
        if (Treasurehit.collider != null && Treasurehit.collider.gameObject.name == "Chest")
        {
            treasureFind = true;
            treasurepath = PathNum;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        DirectionTile controller = other.GetComponent<DirectionTile>();
        if (controller != null)
        {
            FindAPath = true;
        }
    }
}
