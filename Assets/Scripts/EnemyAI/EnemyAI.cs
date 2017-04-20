using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class EnemyAI : MonoBehaviour {

    public Behvior _typeofAI;
    // for wandering
    public Transform PostOne;
    public Transform PostTwo;
    private int direction; 

    // for shooting
    public float Range;

    // References to gun and player controller
    PlayerController _pc;

	// Use this for initialization
	void Start ()
    {
        _pc = GetComponent<PlayerController>();
        _pc.SetAsAI();
        direction = -1;
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    private void FixedUpdate()
    {
        switch (_typeofAI)
        {
            case Behvior.Wanderer:
                Wander();
                break;
            case Behvior.Shooter:
                Shoot();
                break;
        }
    }

    // wander around a given area or just stand still depending on some condition
    void Wander()
    {
        // wanders between two posts
        _pc.MoveSideScroll(direction);

        if (direction == -1 && Close(transform.position.x, PostOne.position.x, 0.1f)||
            direction == 1 && Close(transform.position.x, PostTwo.position.x, 0.1f))
        {
            direction *= -1;
        }
    }

    bool Close(float x1, float x2, float delta)
    {
        return Mathf.Abs(x1 - x2) < delta;
    }

    // follow 
    void Follow()
    {

    }

    // start the attack animation and create a hitting collider
    void Attack()
    {

    }

    // start the shooting animation and shoot a couple of bullets 
    void Shoot()
    {

    }
}
