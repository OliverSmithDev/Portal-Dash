using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float checkOffset = 1f;
    [SerializeField] private float checkRadius = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position + new Vector3(0, checkOffset, 0), checkRadius, Vector3.up);
            foreach (RaycastHit hit in hits)
            {
                if(hit.collider.tag == "Zipline")
                {
                    hit.collider.GetComponent<zipline>().StartZipLine(this.gameObject);
                    Debug.Log("Hit");
                }
            }
        }
    }
}
