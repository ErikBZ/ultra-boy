using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HealthController : MonoBehaviour, IHittable{

	public int Health; //can adjust for health. Enemies will typically have 1


	// Use this for initialization
	void Start () {
		//not needed		
	}

	// Update is called once per frame
	void Update () {
		if (Health == 0) 
		{
			Die ();
		}
	}

	// TODO implmeent this so the player dies when 
	void Die()
	{

		if(gameObject.layer == 9)
			SceneManager.LoadScene ("Gameover");
		//            print("I'm dying nooo");

		if (gameObject.layer == 10)
			Destroy(gameObject);

	}

	public void GiveHit(Collider2D other)
	{
		// this doesn't hit anything
	}

	public void TakeHit()
	{
		// this kills the gameobject.
		Health--;
		//ha!
		if(Health <= 0)
			Die();
	}
}
