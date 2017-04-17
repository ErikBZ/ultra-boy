using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour, IHittable{

    public bool Alive;


    // Use this for initialization
    void Start () {
        Alive = true;		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // TODO implmeent this so the player dies when 
    void Die()
    {
        print("I'm dying nooo");
    }

    public void GiveHit(Collider2D other)
    {
        // this doesn't hit anything
    }

    public void TakeHit()
    {
        // this kills the gameobject.
        Die();
    }
}
