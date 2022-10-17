using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Keyfragments : MonoBehaviour
{
    public static int Fragments;
    public Text KeyFragment;
  
    void Update()
    {
        KeyFragment.text = "Fragments gathered =  " + Fragments;

        if (Fragments == 3)
        {
            SceneManager.LoadScene("EndGame");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            Fragments++;
            Destroy(other.gameObject);
        }
    }
}
