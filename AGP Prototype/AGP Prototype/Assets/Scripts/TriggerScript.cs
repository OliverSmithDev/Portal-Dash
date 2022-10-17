using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public Collider Wall;
    // Start is called before the first frame update
    void Start()
    {
        Wall.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Wall.isTrigger = true;
            StartCoroutine(TriggerControl());
            
        }
    }

    IEnumerator TriggerControl()
    {
        yield return new WaitForSeconds(5);
        Wall.isTrigger = false;
    }

   
}
