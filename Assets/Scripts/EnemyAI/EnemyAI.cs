using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class EnemyAI : MonoBehaviour, IHittable
{

    public Behvior _typeofAI;
    // for wandering
    public Transform PostOne;
    public Transform PostTwo;
    private int direction;

    // for shooting
    public float Range;
    public Transform playerCharacter;

    // References to gun and player controller
    PlayerController _pc;

    // Use this for initialization
    void Start()
    {
        playerCharacter = null;
        _pc = GetComponent<PlayerController>();
        _pc.SetAsAI();
        direction = -1;
    }

    // Update is called once per frame
    void Update()
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

        if (direction == -1 && Close(transform.position.x, PostOne.position.x, 0.1f) ||
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
        if(playerCharacter == null)
        {
            return;
        }

        CheckPlayerCharacterPosition(playerCharacter);
        _pc._gun.Shoot();
    }

    void CheckPlayerCharacterPosition(Transform player)
    {
        if(player == null)
        {
            // don't do anything
            return;
        }

        // the player is to the right of this enemy
        if(player.position.x > transform.position.x && !_pc.FacingRight)
        {
            _pc.Flip();
        }
        // player is not to the left of this enemy
        else if(player.position.x < transform.position.x && _pc.FacingRight)
        {
            _pc.Flip();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Behvior.Shooter == _typeofAI)
        {
            GameObject go = collision.GetComponent<Collider2D>().gameObject;
            if (go.layer == 9)
            {
                if (go.GetComponent<PlayerController>() != null)
                {
                    playerCharacter = go.transform;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Behvior.Shooter == _typeofAI)
        {
            GameObject go = collision.GetComponent<Collider2D>().gameObject;
            if (go.layer == 9)
            {
                if (go.GetComponent<PlayerController>() != null)
                {
                    playerCharacter = null;
                }
            }
        }
    }

	public void TakeHit()
	{
	}

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
