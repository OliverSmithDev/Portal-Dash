using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentScript : MonoBehaviour
{

    public GameObject Button;
    public GameObject Door;
    Vector3 VectorUp;
    Vector3 VectorDown;
    public bool DoorOpen = false;
    public bool DoorShut = true;
    public bool CanOpen;
    public bool CanMoveUp;
    public bool CanMoveDown;
    public bool DoorRed;
    public bool DoorBlue;
    public Vector3 StartingPos;

    Rigidbody rb;
    float Speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        VectorUp = new Vector3(0, 3, 0);
        VectorDown = new Vector3(0, -3, 0);
        StartingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (WallScript.ResetMovers == true)
        {
            transform.position = StartingPos;
        }
       if(Input.GetKeyDown(KeyCode.E) && CanOpen == true)
       {

            if (DoorShut == true)
            {
                DoorOpenn();
            }
            else DoorShutt();
            
       }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            CanOpen = true;
            
            
           
           // print("DoorOperate");
        }

        if (other.tag == "Player" && CanMoveUp == true)
        {
            transform.position += Vector3.up * Time.deltaTime;
            //rb.velocity = transform.up * Speed;
            print("PlayerElevator");
        }
        if (other.tag == "Player" && CanMoveDown == true)
        {
            transform.position += Vector3.down * Time.deltaTime;
        }

    }

    
    
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "TopElevator")
        {
            CanMoveUp = false;
            CanMoveDown = true;
            print("TopEl");
        }
        if (other.tag == "BottomElevator")
        {
            CanMoveUp = true;
            CanMoveDown = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") 
        {
            CanOpen = false;
            
        }
    }

    public void DoorOpenn()
    {
        if(DoorShut == true && DoorRed == true && BatteryManager.RedBattery > 0.5)
        {
            BatteryManager.RedBattery -= 0.5f;
            Door.transform.position += VectorUp;
            Debug.Log("DoorOpen");
            CanOpen = false;
            DoorShut = false;
            
        }

        if (CanOpen == true && Input.GetKeyDown(KeyCode.E) && DoorShut == true && DoorBlue == true && BatteryManager.BlueBattery > 0.5)
        {
            BatteryManager.BlueBattery -= 0.5f;
            Door.transform.position += VectorUp;
            Debug.Log("DoorOpen");
            CanOpen = false;
            DoorShut = false;

        }
       

    }

    public void DoorShutt()
    {
        if (DoorShut == false)
        {
            Door.transform.position += VectorDown;
            print("DoorShut");
            CanOpen = false;
            DoorShut = true;
        }
    }
   
}
