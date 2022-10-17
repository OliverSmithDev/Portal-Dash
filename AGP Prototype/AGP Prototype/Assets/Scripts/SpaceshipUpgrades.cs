using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpaceshipUpgrades : MonoBehaviour
{
    public float RedNeeded;
    public float BlueNeeded;
    public float PurpleNeeded;

    public bool EnoughRed;
    public bool EnoughBlue;
    public bool EnoughPurple;

    public bool CanActivate;
    public bool ShipRepaired;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanActivate == true && Input.GetKeyDown(KeyCode.E))
        {
            if(BatteryManager.RedRounded >= 10)
            {
                EnoughRed = true;
            }
            if (BatteryManager.PurpleRounded >= 10)
            {
                EnoughPurple = true;
            }
            if (BatteryManager.BlueRounded >= 10)
            {
                EnoughBlue = true;
            }
        }

        if( EnoughRed == true && EnoughBlue == true && EnoughPurple == true)
        {
            BatteryManager.RedRounded -= 10;
            BatteryManager.BlueRounded -= 10;
            BatteryManager.PurpleRounded -= 10;
            ShipRepaired = true;
        }

        if(ShipRepaired == true)
        {
            WonGame();
        }
    }

    void WonGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CanActivate = true;
        }
    }
}
