using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomEntrance : MonoBehaviour
{

    public bool EnterRoom = false;
    public GameObject SelectionMenu;
    public GameObject Red;
    public GameObject Blue;
    public GameObject RedTrans;
    public GameObject BlueTrans;
    public float CountDownTimer = 5f;
    public static int Charge = 100;
    public int Charge2;
    public Text ChargeText;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible= true;
    }

    // Update is called once per frame
    public void Update()
    {
        ChargeText.text = "Charges " + Charge;
        Charge2 = Charge;


        if(EnterRoom == true && Charge > 0)
        {
            SelectionMenu.SetActive(true);
            PlayerMove.CanMove = false;
            //GetComponent<PlayerMove>().enabled = false;
            GameObject.Find("Camera").GetComponent<PlayerSee>().enabled = false;





        }
        if(SelectionMenu.active == true)
        {
            CountDownTimer -= Time.deltaTime;
            
           
        }
        else if (SelectionMenu.active == false)
        {
            CountDownTimer = 5f;
            //GetComponent<PlayerMove>().enabled = true;
            GameObject.Find("Camera").GetComponent<PlayerSee>().enabled = true;
            PlayerMove.CanMove = true;

        }
        if (CountDownTimer <= 0)
        {
            SelectionMenu.SetActive(false);
            RedOption();
        }

        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ColourChange")
        {
            EnterRoom = true;
        }
        
        if(other.tag == "RoomComplete")
        {

        }
    }

    public void RedOption()
    {
        print("ClickedR");
        Red.SetActive(true);
        RedTrans.SetActive(false);
        BlueTrans.SetActive(true);
        EnterRoom = false;
        SelectionMenu.SetActive(false);
        Blue.SetActive(false);
        Charge--;
    }
    public void BlueOption()
    {
        Blue.SetActive(true);
        BlueTrans.SetActive(false);
        RedTrans.SetActive(true);
        EnterRoom = false;
        SelectionMenu.SetActive(false);
        Red.SetActive(false);
        Charge--;
    }

}
