using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalTimer : MonoBehaviour
{
    public static bool TimerTrue;
    public float Timer = 1;
    public float Timer2;
    public Transform Resetlocation;
    public GameObject Player;
    public float SetTimer;
    public int BatteryAmount;
    public int BatteryAmount2;
    public int TimerMulti;
    public GameObject GameManagerOBJ;
    public GameObject PortalMain;

    public GameObject PortalMenu;
    public Text BatteryAmountText;
    public Text TimeGiven;
    public Text TimerText;
    public bool CanActivate = false;
    public static bool ActivatePortal;
    public static bool MenuActive = false;
    public static bool EnteredPortal;
   
    
    // Start is called before the first frame update
    void Start()
    {
        GameManagerOBJ.GetComponent<PortalTextureSetup>().enabled = false;
        PortalMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        

        TimerText.text = "Timer :" + Timer.ToString("f2");
        if (CanActivate == true && Input.GetKeyDown(KeyCode.E))
        {
            PortalMenu.SetActive(true);
            PlayerMove.CanMove = false;
            print("Plaeyermove");
            MenuActive = true;
        }

        if (PortalMenu.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerMove.CanMove = true;
        }

        if(TimerTrue == true)
        {
            Timer -= Time.deltaTime;
        }

        if(Timer <= 0 && TimerTrue == true)
        {
            PullPlayerBack();
        }
        Timer2 = BatteryAmount * 20 + 30;
        TimeGiven.text = ("Time in level = " + Timer2);
        BatteryAmountText.text = ("Amount of batteries =   " + BatteryAmount);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            CanActivate = true;
        }

        if(other.tag == "PortalIn")
        {
            TimerTrue = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CanActivate = false;
        }
    }
    void PullPlayerBack()
    {
        Player.transform.position = Resetlocation.position;
        TimerTrue = false;
        Timer = 10;
        GameManagerOBJ.GetComponent<PortalTextureSetup>().enabled = false;
        PortalMain.SetActive(false);
        BatteryAmount = 0;
    }

    public void AddBattery()
    {
        if(BatteryManager.BlueBattery >= 1)
        {
            BatteryAmount++;
            BatteryManager.BlueBattery -= 1;
        }
       
    }
    public void RemoveBattery()
    {
        if(Timer2 > 30)
        {
            BatteryAmount--;
            BatteryManager.BlueBattery +=1;
        }
        if(Timer2 <= 30)
        {
            Timer2 = 30;
        }
        
    }
    public void StartPortal ()
    {
        Timer = Timer2;
       // TimerTrue = true;
        PortalMenu.SetActive(false);
        PortalMain.SetActive(true);
        PlayerMove.CanMove = true;
        MenuActive = false;
        GameManagerOBJ.GetComponent<PortalTextureSetup>().enabled = true;
    }
}
