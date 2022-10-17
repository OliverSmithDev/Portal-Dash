using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject Camera1st;
    public GameObject Camera3rd;
    public bool IsThird;
    // Start is called before the first frame update
    void Start()
    {
        Camera3rd.SetActive(true);
        Camera1st.SetActive(false);
        IsThird = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && IsThird == true)
        {
            Camera3rd.SetActive(false);
            Camera1st.SetActive(true);
            IsThird = false;
        }

        else if (Input.GetKeyDown(KeyCode.Q) && IsThird == false)
        {
            Camera3rd.SetActive(true);
            Camera1st.SetActive(false);
            IsThird = true;
        }
    }
}
