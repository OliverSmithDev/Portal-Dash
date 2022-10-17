using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPowerUp : MonoBehaviour
{
    public float Timer;
    public bool PullPlayerOut;
    public Transform ResetPoint;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer <= 0)
        {
            PullPlayerOut = true;
        }

        if(PullPlayerOut == true)
        {
            PullPlayer();
             

            
        }
    }

    void PullPlayer()
    {
        //Pull the player out of the area
        Player.transform.position = ResetPoint.transform.position;
    }

}
