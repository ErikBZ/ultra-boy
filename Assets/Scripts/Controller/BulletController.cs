using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IHittable
{
    //variable we can change to modify the speed of the bullet
    public float Speed;
    public int Damage;
    public Vector2 vel;

    public int ownerLayer;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //code for the speed of the bullets
	}

	// This seems to work over OnTriggerEnter2d
	private void OnCollisionEnter2D(Collision2D other)
	{
		//this checks if the thing its hitting is an enemy. If its an enemy it "deletes" its.
		//we can modify this once we get health working.
		if ((other.gameObject.layer == 10 || other.gameObject.layer == 9) && other.gameObject.layer != ownerLayer) {
			GiveHit (other.collider);

		}
		Destroy(gameObject);
	}

	//	void OnTriggerEnter2D(Collider2D other)
	//	{
	//		//this checks if the thing its hitting is an enemy. If its an enemy it "deletes" its.
	//		//we can modify this once we get health working.
	//		if ( (other.gameObject.layer == 10 || other.gameObject.layer == 9) && other.gameObject.layer != ownerLayer)
	//		{
	//			GiveHit(other);
	//		}
	//
	//		Destroy(gameObject);
	//	}

    public void SetDirection(int i)
    {
        Speed = Speed * i;
        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    public void GiveHit(Collider2D other)
    {
        IHittable obj = other.GetComponent<IHittable>();
        if (obj != null)
        {
            for (int i = 0; i < Damage; i++)
            {
                obj.TakeHit();
            }
        }
    }


    public void TakeHit()
    {
    }
}
