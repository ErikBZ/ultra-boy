using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    //used to link the Bullet GameObject(asset)
    public GameObject Bullet;

    //the firerate of the gun. higher is slower. Mess with decimals to get it to go fast
    public float fireRate;

    //the point from which the bullets fire
    public Transform firePoint;

    //used to track the the last time a bullet was shot
    private float lastShot = 0;

    //needed so the player can shoot as soon as they are put in the game
    private bool canShoot;

	// Use this for initialization
	void Start ()
    {
        canShoot = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //not needed
	}

    // TODO shoot the bullet
    public void Shoot()
    {
        // instantiate a bullet then shoot it
        print("bang"); //we can keep this for test purposes

        // this or isn't needed, just make sure that Time.time is greater than the lastshot
        // plus the fire rate
        // TODO get ride of canShoot
        if ((Time.time > fireRate + lastShot) || canShoot == true)
        {
            //"Shoots" by spawning a Bullet asset at firePoint. Bullet has a BulletController on it adjust speed.

            GameObject bullet = Instantiate(Bullet, firePoint.position, firePoint.rotation);
            lastShot = Time.time;

            if (!gameObject.GetComponent<PlayerController>().FacingRight)
            {
                bullet.GetComponent<BulletController>().SetDirection(-1);
            }

            bullet.GetComponent<BulletController>().ownerLayer = this.gameObject.layer;
            // this will either be 9 or 8
            // will cause enemies to not collide with enmey bullets
            // and player bullets not to collide with player bullets
            bullet.layer = this.gameObject.layer;

            //used to adjust to canShoot
            if (Time.time > fireRate + lastShot)
                canShoot = true;
            else
                canShoot = false;
        }
    }

}
