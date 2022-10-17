using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTp : MonoBehaviour
{
    public Transform player;
    public Transform PortalRecive;
    public GameObject Walls;
    public bool PlayerIsColliding = false;
    // Start is called before the first frame update
    void Start()
    {
        Walls.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerIsColliding)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProduct < 0f)
            {
                float RotDif = Quaternion.Angle(transform.rotation, PortalRecive.rotation);
                RotDif += 180;
                player.Rotate(Vector3.up, RotDif);
                Vector3 positionOffSet = Quaternion.Euler(0f, RotDif, 0f) * portalToPlayer;
                player.position = PortalRecive.position + positionOffSet;
                Walls.SetActive(true);
                PlayerIsColliding = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerIsColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerIsColliding = false;
    }
}
