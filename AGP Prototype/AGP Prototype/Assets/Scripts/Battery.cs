using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{

    public float BatteryPower = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
        BatteryPower = 1f;
        //BatteryPower = Random.Range(0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
