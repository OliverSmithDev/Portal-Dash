using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float lastScore;
    public float highscore;
    public static GameManager instance
    {
        get;
        set;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        instance = this;
    }

    public void GameOver(float endingScore)
    {
        lastScore = endingScore;
        calculateHighscore();
        SceneManager.LoadScene(2);
    }
    public void GameWin(float endingScore)
    {
        lastScore = endingScore;
        calculateHighscore();
        SceneManager.LoadScene(3);
    }
    void calculateHighscore()
    {
        if (lastScore > highscore)
        {
            highscore = lastScore;
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Win()
    {
        SceneManager.LoadScene(3);
    }
    public void Credits()
    {
        SceneManager.LoadScene(4);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
