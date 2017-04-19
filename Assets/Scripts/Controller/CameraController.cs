using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cameraObj;
    public float smoothSpeed; //Must be > 1 for the script to work.
    private float OZ;

    // Use this for initialization
    void Start()
    {
        cameraObj = Camera.main;
        OZ = cameraObj.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetPOS = Vector3.Lerp(cameraObj.transform.position, transform.position, smoothSpeed * Time.deltaTime); //lerps to smooth
        cameraObj.transform.position = new Vector3(targetPOS.x, targetPOS.y, OZ); //move the camera
    }
}
