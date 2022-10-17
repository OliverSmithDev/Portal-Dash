using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject WallObj;
    public AudioSource InLevelMusic;
    public AudioSource SpaceShipMusic;
    public static bool ResetMovers;
    public bool ResetMover2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MenusScript.PausedGame == true)
        {
            InLevelMusic.Pause();
        }
        if(MenusScript.PausedGame == false)
        {
            InLevelMusic.UnPause();
        }

        if(ResetMover2 == true)
        {
            print("Resetmover2");
        }
        if (ResetMover2 == false)
        {
            print("Resetmover22222");
        }
        ResetMover2 = ResetMovers;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PortalReturn")
        {
            ResetMovers = true;
            print("ResetPossss");
            WallObj.SetActive(false);
            InLevelMusic.Stop();
            SpaceShipMusic.Play();
           
            
        }

        if(other.tag == "PortalB")
        {
            WallObj.SetActive(true);
            InLevelMusic.Play();
            SpaceShipMusic.Play();
            ResetMovers = false;
        }
        if (other.tag == "PortalC")
        {
            WallObj.SetActive(true);
            InLevelMusic.Play();
            SpaceShipMusic.Play();
            ResetMovers = false;
        }
        if (other.tag == "PortalD")
        {
            WallObj.SetActive(true);
            InLevelMusic.Play();
            SpaceShipMusic.Play();
            ResetMovers = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "PortalReturn")
        {
            ResetMovers = false;
        }
    }
}
