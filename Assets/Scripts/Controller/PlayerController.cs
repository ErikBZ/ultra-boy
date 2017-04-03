using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Since script controls how the character moves
// it needs access to that Character's rigidbody and 
// therefore must be required
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]

// nothing in these scripts that inherit from MonoBehaviour should 
// have public variables
// details on rigidbodies can be found at
// https://docs.unity3d.com/ScriptReference/Rigidbody2D.html
public class PlayerController : MonoBehaviour
{

	// GameObjects compontents and references
	Rigidbody2D rb;
    // this isn't needed just yet
    // Animator animator;

	//moving variables
	public float topSpeed = 10f;
	bool facingRight = true;

	//jumping variable
	bool grounded = false;

    // TODO make this into a reference for GroundChecker
    // that has a bool called "grounded" which keeps track of
    // the player's relation to the ground
	public Transform groundCheck;  //check to see if character is grounded
	float groundRadius = 0.2f; // How big circle is going to be when checking distance to the ground
	public float jumpForce = 500f; // force of the jump
	public LayerMask whatIsGround; // what layer is considered the ground

	// Use this for initialization
	// this is basically a constructor
	private void Start()
	{
		// getting a reference to this gameobejcts rigdbody
		rb = GetComponent<Rigidbody2D>();
		//animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	// DO NOT USE FOR MOVEMENT
	private void Update()
	{
		if (grounded && Input.GetKeyDown (KeyCode.Space)) 
		{
            // not on ground
            //animator.SetBool ("Ground", false);
            
            // all this stuff should be done in Jump() too
            // add jump force to character's y-axis 
            // setting veloctiy may be a better choice
            // rb.velocity = someVel;
            rb.AddForce(new Vector2(0, jumpForce));
		}

	}

	// Fixed Update should be used whenever doing anything
	// with phyiscs
	private void FixedUpdate()
	{
		Jump ();
		MoveSideScroll ();
		// have logic here where it checks for what buttons are pressed down

		// the "jump" button is just
		// Input.GetAxis returns a float
		print("The 'Jump' axis is returning: " + Input.GetAxis("Jump"));

		print("The 'Horizontal' axis is returning: " + Input.GetAxis("Horizontal"));
	}

	// use this method for jumping
	private void Jump()
	{
		// check for ground contact
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
        // you have to use the rigidbody to set the velocty
	}

	// this method should be used for moving left and right
	private void MoveSideScroll()
	{
		//get move direction
		float move = Input.GetAxis ("Horizontal");

		//add velocity to the rigidbody in the move direction * speed
		rb.velocity = new Vector2(move*topSpeed, rb.velocity.y);

        //Set a float to speed based on the amt of float value (0.1)
        // this once we have a sprite to animate. for now leave it commented
        // animator.SetFloat ("Speed", Mathf.Abs (move));

		//flip direction
		if (move > 0 && !facingRight) 
		{
			Flip ();
		}
		else if( move < 0 && facingRight )
		{
			Flip();
		}
	}

	// Flip rigidbody facing
	void Flip()
	{
		// Indicate facing oposite direction
		facingRight = !facingRight;

		// Get the local Scale
		Vector3 theScale = transform.localScale;

		//flip on x axis
		theScale.x *= -1;

		//apply flip to local scale
		transform.localScale = theScale;
	}
}