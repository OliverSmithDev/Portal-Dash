using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryUsage : MonoBehaviour
{
    public bool CanOpen;
    public float BlueBattery;
    public static float RedBattery;
    public float RedBattery1;

    public bool RedButtonCol;
    public bool BlueButtonCol;
    public bool CollideWithButton;
    public bool OnRed;
    public bool OnBlue;
    public static bool PeoplemoverCanGo;


    public GameObject Red;
    public GameObject Blue;
    public GameObject RedTrans;
    public GameObject BlueTrans;

    Rigidbody rb;
    float Speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        OnBlue = true;
        OnRed = true;
    }

    // Update is called once per frame
    void Update()
    {

        RedBattery1 = RedBattery;
       BlueBattery = BatteryManager.BlueRounded;
       RedBattery = BatteryManager.RedRounded;

        if(PeoplemoverCanGo == true && Input.GetKeyDown(KeyCode.E))
        {
            PeopleMover.CanMove = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && CollideWithButton == true)
        {
            
            ButtonPress();
        }

        if(BatteryManager.BlueBattery <= 0)
        {
            BatteryManager.BlueBattery = 0;
        }
        if (BatteryManager.RedBattery <= 0)
        {
            BatteryManager.RedBattery = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "ButtonRed")
        {
            RedButtonCol = true;
            
            CollideWithButton = true;
        }
        if (other.tag == "ButtonRedPeopleMover")
        {
            
            PeoplemoverCanGo = true;
            
        }

        if (other.tag == "ButtonBlue")
        {
            BlueButtonCol = true;
            CollideWithButton = true;
        }

        if(other.tag == "Elevator")
        {
            rb.velocity = transform.up * Speed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ButtonRed" || other.tag == "ButtonBlue")
        {
            CollideWithButton = false;
            RedButtonCol = false;
            BlueButtonCol = false;

        }
        if (other.tag == "ButtonRedPeopleMover")
        {

            PeoplemoverCanGo = false;
        }
    }

    public void ButtonPress()
    {
        if (RedButtonCol == true && BatteryManager.RedBattery >= 1)
        {
            if(OnBlue == true )
            {
                BatteryManager.RedBattery -= 1f;
            }
            Red.SetActive(true);
            RedTrans.SetActive(false);
            BlueTrans.SetActive(true);
            Blue.SetActive(false);
            CollideWithButton = false;
            RedButtonCol = false;
            OnRed = true;
            OnBlue = false;
        }
        else if (BlueButtonCol == true && BatteryManager.BlueBattery >= 1)
        {
            if (OnRed == true )
            {
                BatteryManager.BlueBattery -= 1f;
            }
            Blue.SetActive(true);
            BlueTrans.SetActive(false);
            RedTrans.SetActive(true);
            Red.SetActive(false);
            CollideWithButton = false;
            BlueButtonCol = false;
            OnBlue = true;
            OnRed = false;
        }

    }
}
