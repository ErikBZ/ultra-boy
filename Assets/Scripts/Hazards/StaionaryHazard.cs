using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaionaryHazard : MonoBehaviour, IHittable {


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // TODO implement both these functions
    // if the player gets to close to this object, then it must be
    // "hit" so this script will call "Give Hit"
    // these are just alternatives to "OnCollison2DEnter" and "OnCollision2DExit"
    // if it's easier we can use those

    // This is what happens if something hits this object
    public void TakeHit()
    {
        // this can't be destroyed, so it does nothing when hit
        // by anyting

    }

    // what happens if this object hits another
    public void GiveHit(Collider2D other)
    {
        if(other.gameObject.layer == 9)
        {
            print("The player has hit a stationary object that damages it\nIt must now die");
            IHittable obj = other.GetComponent<IHittable>();
            if(obj != null)
            {
                obj.TakeHit();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GiveHit(collision.collider);
    }
}
