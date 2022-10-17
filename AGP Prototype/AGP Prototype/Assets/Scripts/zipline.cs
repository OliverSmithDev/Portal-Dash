using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zipline : MonoBehaviour
{
    [SerializeField] private zipline targetZip;
    [SerializeField] private float zipSpeed = 5f;
    [SerializeField] private float zipScale = 0.2f;
    [SerializeField] private LineRenderer cable;

    [SerializeField] private float arrivalThreshold = 0.4f;
    public Transform ZipTransform;
    public Transform ZipTarget;
    private bool zipping = false;
    private GameObject localZip;

    Transform pl;
    public Vector3 offset = new Vector3(0,-1,0);
   
    // Start is called before the first frame update
    void Awake()
    {
        cable.SetPosition(0, ZipTransform.position);
        cable.SetPosition(1, targetZip.ZipTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!zipping || localZip == null) return;

        localZip.GetComponent<Rigidbody>().AddForce((targetZip.ZipTransform.position - ZipTransform.position).normalized * zipSpeed * Time.deltaTime, ForceMode.Acceleration);

        if(Vector3.Distance(localZip.transform.position, targetZip.ZipTransform.position) <= arrivalThreshold)
        {
            ResetZipline();
        }

        if(zipping)
        {
            pl.position = localZip.transform.position + offset;
        }
    }

    public void StartZipLine(GameObject player)
    {
        if (zipping) return;

        pl = player.transform;

        localZip = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        
        localZip.transform.position = ZipTransform.position;
        localZip.transform.localScale = new Vector3(zipScale, zipScale, zipScale);
        localZip.AddComponent<Rigidbody>().useGravity = false;
        localZip.GetComponent<Collider>().isTrigger = true;

        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<PlayerMove>().enabled = false;
        player.transform.parent = localZip.transform;
        zipping = true;

        Debug.Log("StartZip");
    }

    private void ResetZipline()
    {
        if (!zipping) return;

        GameObject player = localZip.transform.GetChild(0).gameObject;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
       // PlayerMove.CanMove = true;
        player.GetComponent<PlayerMove>().enabled = true;
        player.transform.parent = null;
        Destroy(localZip);
        localZip = null;
        zipping = false;
        Debug.Log("ResetZip");
    }
}
