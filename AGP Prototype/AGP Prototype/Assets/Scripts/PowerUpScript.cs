using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUpCharge")
        {
            RoomEntrance.Charge++;
            Destroy(other.gameObject);
        }

        if(other.tag == "SpeedIncrease")
        {
            PlayerMove.moveSpeed = 15f;
            yield return new WaitForSeconds(5);
            PlayerMove.moveSpeed = 6f;
        }
    }

}
