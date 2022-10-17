using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float Timerr;
    public Text TimerText;
    public Text highScore;
    public bool TimerActive = true;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "HighScore :" + PlayerPrefs.GetFloat("HighScore", 1000);
       // PlayerPrefs.DeleteKey("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerActive == true)
        {
            Timerr += Time.deltaTime;
            
        }
        TimerText.text = "Timer :" + Timerr.ToString("f2");
        if(Keyfragments.Fragments >= 2)
        {
            TimerActive = false;
            GameFinished();
        }
    }

    public void GameFinished()
    {
        if (Timerr <= PlayerPrefs.GetFloat("HighScore", 0))
        {
            print("GameFinished");
            PlayerPrefs.SetFloat("HighScore", Timerr);
            highScore.text = "HighScore :" + Timerr;
        }
    }
}
