using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleMover : MonoBehaviour
{
    public float Timerr;
    public static bool CanMove = false;
    public float movementSpeed = 1f;
    public GameObject PeopleMoverWall;
    public bool Tester;
    public Transform target;
    public Transform target2;
    public bool GoingForward = true;
    public Vector3 StartingArea;
    // Start is called before the first frame update
    void Start()
    {
        PeopleMoverWall.SetActive(false);

        StartingArea = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (WallScript.ResetMovers == true)
        {
            transform.position = StartingArea;
           
            //WallScript.ResetMovers = false;
        }
        float step = movementSpeed * Time.deltaTime;
        if (CanMove == true)
        {
            Tester = true;
        }
        if (CanMove == true && GoingForward == true) //&& Timer > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
           
            PeopleMoverWall.SetActive(true);
        }
        if (CanMove == true && GoingForward == false) //&& Timer > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2.position, step);

            PeopleMoverWall.SetActive(true);
        }

        if (Vector3.Distance(transform.position, target.position) < 0.001f || Vector3.Distance(transform.position, target2.position) < 0.001f)
        {
            print("AtTarget");
            PeopleMoverWall.SetActive(false);
            CanMove = false;
            
            if (GoingForward == true)
            {
                GoingForward = false;
            }
            else GoingForward = true;
           
        }

    }
}

