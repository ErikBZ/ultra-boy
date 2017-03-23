using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// remember to add this to the "Main Camera" game object so that the script actually runs
public class CameraController : MonoBehaviour {

    /*
     * This will directly reference the "Transform" object from
     * the player GameObject. We don't reference Tranform, or PlayerController
     * because we only need to know the position which is saved under Transform
     */
    Transform player;

	// Use this for initialization
	void Start () {
		// No initialzation is needed for this because
        // we can just set player in the Unity editor by dragging 
        // the Main Character game object into the "Transform" player field
        // found on this scripts section
	}
	
	// Update is called once per frame
    // we are using this because we should not be
    // doing any physics calucalations on the Camera, like
    // gravity, or some external force. We can stilll have
    // velocity though, or some sort of position change.
	void Update () {
        // if there is no player then the camera will remain still
        if(player != null)
        {
            // we update here or do some other checks
        }
	}

    // one way to test this is to set the position of the main character
    // higher and let it drop. This way you don't need to wait for the PlayerController to
    // be finished
    void UpdateCamera()
    {
        // put the code for how you will update the camera here
    }
}
