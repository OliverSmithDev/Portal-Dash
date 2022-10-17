using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalColTest : MonoBehaviour
{
    public static bool PortalB;
    public static bool PortalC;
    public static bool PortalD;
    public static bool PortalReturn;

    public GameObject CameraAB;
    public GameObject CameraAC;
    public GameObject CameraAD;

    public bool PortalTest;

    // Start is called before the first frame update
    void Start()
    {
        CameraAB.SetActive(true);
        CameraAC.SetActive(false);
        CameraAD.SetActive(false);
        PortalB = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(PortalTest == true)
        {
            PortalB = true;
             PortalC = false;
             PortalD = false;
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PortalB")
        {
            PortalB = true;
            PortalC = false;
            PortalD = false;
            
           // CameraAB.SetActive(true);
            //CameraAC.SetActive(false);
            //CameraAD.SetActive(false);
            print("PortalB");
        }
        if (other.tag == "PortalC")
        {
            PortalC = true;
            PortalB = false;
            PortalD = false;
            //CameraAB.SetActive(false);
           // CameraAC.SetActive(true);
           // CameraAD.SetActive(false);
            print("PortalC");
        }
        if (other.tag == "PortalD")
        {
            PortalD = true;
            PortalB = false;
            PortalC = false;
            //CameraAB.SetActive(false);
           // CameraAC.SetActive(false);
           // CameraAD.SetActive(true);

            print("PortalD");
        }
        if(other.tag == "PortalReturn")
        {
            PortalTest = true;
            PortalTimer.TimerTrue = false;
           
        }
        if(other.tag == "PortalTimerStart")
        {
            PortalTimer.TimerTrue = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "PortalReturn")
        {
            PortalTest = false;
            
        }
        
    }
}
