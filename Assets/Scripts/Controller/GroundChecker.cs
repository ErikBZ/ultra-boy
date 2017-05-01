using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour {

    public bool grounded;

	// Use this for initialization
	void Start () {
        grounded = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.GetComponent<Collider2D>().gameObject.layer == 10)
        {
            grounded = true;
        }
    }

    // precauation since sometimes the jump causes some weird glitches
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().gameObject.layer == 0)
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        grounded = false;
    }
}
