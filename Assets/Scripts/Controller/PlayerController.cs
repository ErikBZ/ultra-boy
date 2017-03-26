using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Since script controls how the character moves
// it needs access to that Character's rigidbody and 
// therefore must be required
[RequireComponent(typeof(Rigidbody2D))]

// nothing in these scripts that inherit from MonoBehaviour should 
// have public variables
// details on rigidbodies can be found at
// https://docs.unity3d.com/ScriptReference/Rigidbody2D.html
public class PlayerController : MonoBehaviour
{

    // GameObjects compontents and references
    Rigidbody2D rb;

    // Use this for initialization
    // this is basically a constructor
    private void Start()
    {
        // getting a reference to this gameobejcts rigdbody
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // DO NOT USE FOR MOVEMENT
    private void Update()
    {


    }

    // Fixed Update should be used whenever doing anything
    // with phyiscs
    private void FixedUpdate()
    {
        // have logic here where it checks for what buttons are pressed down

        // the "jump" button is just
        // Input.GetAxis returns a float
        print("The 'Jump' axis is returning: " + Input.GetAxis("Jump"));

        print("The 'Horizontal' axis is returning: " + Input.GetAxis("Horizontal"));
    }

    // use this method for jumping
    private void Jump()
    {

    }

    // this method should be used for moving left and right
    private void MoveSideScroll()
    {

    }
}