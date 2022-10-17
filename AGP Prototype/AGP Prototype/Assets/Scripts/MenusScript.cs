using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusScript : MonoBehaviour
{
    
    public GameObject MenuUi;
    public bool PauseMenu = false;
    public static bool PausedGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(PauseMenu == true)
            {
                MenuUi.SetActive(false);
                PauseMenu = false;
                PausedGame = false;
                print("PauseMenuOff");
                GameObject.Find("Camera").GetComponent<PlayerSee>().enabled = true;
            }
            else if(PauseMenu == false)
            {
                MenuUi.SetActive(true);
                PausedGame = true;
                PauseMenu = true;
                print("PauseMenuOn");
                GameObject.Find("Camera").GetComponent<PlayerSee>().enabled = false;

            }

         
      

        }
       

        if (PauseMenu == true)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1f;
    }

    public void Play()
    {
        MenuUi.SetActive(false);
        PauseMenu = false;
        GameObject.Find("Camera").GetComponent<PlayerSee>().enabled = true;
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void MainMenuPlay()
    {
        SceneManager.LoadScene("PortalTest");
    }
    public void MainMenuExit()
    {
        Application.Quit();
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Restart()
    {
        SceneManager.LoadScene("PortalTest");
    }
 


}

