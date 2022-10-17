using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera CameraA;
    public Camera CameraA2;
    public Camera CameraA3;
    public Material CameraMatA;
    public Material CameraMatA2;
    public Material CameraMatA3;
    public Camera CameraB;
    public Material CameraMatB;
    public Camera CameraC;
    public Material CameraMatC;
    public Camera CameraD;
    public Material CameraMatD;

    // Start is called before the first frame update
    void Start()
    {
        if (CameraA.targetTexture != null)
        {
            CameraA.targetTexture.Release();
        }
        CameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraMatA.mainTexture = CameraA.targetTexture;
       

        if (CameraB.targetTexture != null)
        {
            CameraB.targetTexture.Release();
        }
        CameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraMatB.mainTexture = CameraB.targetTexture;
        if (CameraC.targetTexture != null)
        {
            CameraC.targetTexture.Release();
        }
        CameraC.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraMatC.mainTexture = CameraC.targetTexture;
        if (CameraD.targetTexture != null)
        {
            CameraD.targetTexture.Release();
        }
        CameraD.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraMatD.mainTexture = CameraD.targetTexture;
    }

}
