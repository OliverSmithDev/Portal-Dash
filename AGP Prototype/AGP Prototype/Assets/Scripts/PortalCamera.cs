using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    public Transform PortalC;
    public Transform PortalD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PortalColTest.PortalB == true || PortalColTest.PortalReturn == true)
        {
            Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
            transform.position = portal.position + playerOffsetFromPortal;
            float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);
            Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
            Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
        //Portal A-B
        
        if(PortalColTest.PortalC == true)
        {
            Vector3 playerOffsetFromPortal1 = playerCamera.position - PortalC.position;
            transform.position = portal.position + playerOffsetFromPortal1;

            float angularDifferenceBetweenPortalRotations1 = Quaternion.Angle(portal.rotation, PortalC.rotation);

            Quaternion portalRotationalDifference1 = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations1, Vector3.up);
            Vector3 newCameraDirection1 = portalRotationalDifference1 * playerCamera.forward;
            transform.rotation = Quaternion.LookRotation(newCameraDirection1, Vector3.up);
        }
       
        // Portal A-C

        if(PortalColTest.PortalD == true)
        {
            Vector3 playerOffsetFromPortal2 = playerCamera.position - PortalD.position;
            transform.position = portal.position + playerOffsetFromPortal2;

            float angularDifferenceBetweenPortalRotations2 = Quaternion.Angle(portal.rotation, PortalD.rotation);

            Quaternion portalRotationalDifference2 = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations2, Vector3.up);
            Vector3 newCameraDirection2 = portalRotationalDifference2 * playerCamera.forward;
            transform.rotation = Quaternion.LookRotation(newCameraDirection2, Vector3.up);
        }
        
        // Portal A - D
       
    }
}
