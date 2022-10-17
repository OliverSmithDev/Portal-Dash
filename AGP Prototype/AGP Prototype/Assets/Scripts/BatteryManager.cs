using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class BatteryManager : MonoBehaviour
{
    public float BatteryPower;
    public static float BatteryFull;
    public float BatteryFull2;
    public bool CollideWithBattery;
    public static float BlueBattery;
    public static float BlueRounded;
    public static float PurpleBattery;
    public static float PurpleRounded;
    public static float RedBattery;
    public static float RedRounded;

    public float RedBatteryy;
    public float BlueBatteryy;
    public float PurpleBatteryy;
    public bool RedBatteryCol = false;
    public bool BlueBatteryCol = false;
    public bool PurpleBatteryCol = false;
    GameObject BatteryCol;

    public Text BlueText;
    public Text RedText;
    public Text PurpleText;
    
    // Start is called before the first frame update
    void Start()
    {
        RedBattery = 3f;
        BlueBattery = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        RedBatteryy = RedRounded;
        BlueBatteryy = BlueRounded;
        PurpleBatteryy = PurpleRounded;
        BlueRounded = Mathf.Round(BlueBattery * 10.0f) / 10.0f;
        RedRounded = Mathf.Round(RedBattery * 10.0f) / 10.0f;
        PurpleRounded = Mathf.Round(PurpleBattery * 10.0f) / 10.0f;
        //BatteryFull += BatteryPower;
        BatteryFull2 = BatteryFull;
        if (Input.GetKeyDown(KeyCode.R))
        {
            RedBattery += 10;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            BlueBattery += 10;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            PurpleBattery += 10;
        }



        if (Input.GetKeyDown(KeyCode.E) && CollideWithBattery == true)
        {
            BatteryPower = Random.Range(1f, 1f);
            Destroy(BatteryCol.gameObject);
            BatteryPowers();
        }


        PurpleText.text = "Purple Batteries =    " + PurpleRounded;
        BlueText.text = "Blue Batteries =    " + BlueRounded;
        RedText.text = "Red Batteries =    " + RedRounded;
       
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "BatteryRed")
        {
            RedBatteryCol = true;
            BatteryCol = other.gameObject;
            CollideWithBattery = true;
        }

        else if (other.tag == "BatteryBlue")
        {
            BlueBatteryCol = true;
            BatteryCol = other.gameObject;
            CollideWithBattery = true;
        }
        else if(other.tag == "BatteryPurple")
        {
            PurpleBatteryCol = true;
            BatteryCol = other.gameObject;
            CollideWithBattery = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "BatteryRed" || other.tag == "BatteryBlue")
        {
            CollideWithBattery = false;
        }
    }

    public void BatteryPowers()
    {
        if(RedBatteryCol == true)
        {
            RedBattery += BatteryPower;
            CollideWithBattery = false;
            RedBatteryCol = false;
        }
        else if(BlueBatteryCol == true)
        {
            BlueBattery += BatteryPower;
            CollideWithBattery = false;
            BlueBatteryCol = false;
        }
        else if (PurpleBatteryCol == true) 
        {
            PurpleBattery += BatteryPower;
            CollideWithBattery = false;
            PurpleBatteryCol = false;
        }
        
    }
}
