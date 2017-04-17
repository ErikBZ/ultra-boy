using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IHittable{
    // the bullets enemy, this should be changed by GunController since that knows what
    // team it's on, but the bullets don't

    public int enemey;

    // TODO implement this for destroyable hazards
    public void GiveHit(Collider2D other)
    {
        if(other.gameObject.layer == enemey)
        {
            IHittable obj = other.GetComponent<IHittable>();
            // precaution
            if (obj != null)
            {
                obj.TakeHit();
            }
        }
        
    }

    public void TakeHit()
    {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
