using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Takes care of movement, colouring, swiping etc */

public class BallController : MonoBehaviour
{
    // Variables
    public float speed; // Holds the speed of the ball
    private bool isMoving; // Holds check if ball is moving
    private Vector3 travelDirection; // Used to determine the direction the ball is moving in
    private Vector3 nextCollisionPosition; // Holds direction of where the next collision will be
    public int minSwipeSensitivity = 500; // From which minimum swipe distance should the swipe be recognised as a move? Kinda like sensitivity factor
    // Swiping variables
    private Vector2 swipePositionLastFrame;
    private Vector2 swipePositionCurrentFrame;
    private Vector2 swipePositionLastSwipe;
    private Vector2 currentSwipe;

    // References
    public Rigidbody ballRb; // Holds reference to the ball's Rigidbody component

    private void Update()
    {
        // Control the ball's movement
        BallMovement();

        if(isMoving)
        {
            return; // Exit Update() and don't continue executing the code below i.e. ignore anymore user input till end of travel
        }

        // Use user input (swipes) for direction of ball movement
        SwipeMechanism();
    }


    /* Ball Movement */
    private void BallMovement()
    {
         
        // Check Ball is Moving
        if(isMoving) // If the ball is moving
        {
            ballRb.velocity = speed * travelDirection; // Set ball's velocity to the speed in direction of swipe
        }
        
        if(nextCollisionPosition != Vector3.zero) // Check if the ball has hit something
        {
            if(Vector3.Distance(transform.position, nextCollisionPosition) < 1) // Check the distance between the ball's current position and the position of the wall
            {
                isMoving = false; // Ball is not in motion
                travelDirection = Vector3.zero; // Stop the ball from moving
                nextCollisionPosition = Vector3.zero; // Don't have a new position, so wait for new position from swipe
            }
        }
    }
    
    /* Swipe Mechanism */
    private void SwipeMechanism()
    {
        // If user presses the screen...
        if(Input.GetMouseButton(0))
        {
            // Find out the position at the current frame and set it the the var swipePositionCurrentFrame
            swipePositionCurrentFrame = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            // Compare the position to last position
            if(swipePositionLastFrame != Vector2.zero) // Make sure the mouse position is not at the default position i.e. top left of screen
            {
                currentSwipe = swipePositionCurrentFrame - swipePositionLastFrame; // Compare finger/mouse position in current frame with that in last frame
                
                if(currentSwipe.sqrMagnitude < minSwipeSensitivity) // Checks magnitude of swipe against sensitivity
                {
                    return; // If swipe is not strong enough, don't do anything
                }

                // If the swipe is strong enough...
                currentSwipe.Normalize(); // Get the direction of the current swipe

                // Is the swipe Up or Down?
                if(currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) // -0.5 < currentSwipe.x < 0.5
                {
                    // Go Up/Down
                    SetDestination(currentSwipe.y > 0 ? Vector3.forward : Vector3.back);
                }

                // Is the swipe Left or Right?
                if(currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) // -0.5 < currentSwipe.y < 0.5
                {
                    // Go Left/Right
                    SetDestination(currentSwipe.x > 0 ? Vector3.right : Vector3.left);
                }
            }


            swipePositionLastFrame = swipePositionCurrentFrame; // Update the last position each frame
        }

        // If user releases the screen
        if(Input.GetMouseButtonUp(0))
        {
            // Deactivating the swipe mechanism
            swipePositionLastFrame = Vector2.zero; // Resetting the last frame position to zero
            currentSwipe = Vector2.zero; // Resetting the current swipe to zero
        }
    }

    /* Setting the direction of movement based on the vector received from the swipe */
    private void SetDestination(Vector3 direction)
    {
        travelDirection = direction; // Set the travel direction into the new direction passed to the method

        RaycastHit hit; // Check which object the ball will collide with, by casting a beam in the direction the ball is moving

        if(Physics.Raycast(transform.position, direction, out hit, 100f)) // Casts ray from the current position, in the given direction, of length 100 until it hits something
        {
            nextCollisionPosition = hit.point; // Set nextCollisionPosition to the point where we hit the wall i.e. the hit point
        }

        isMoving = true; // Ball is in motion
    }
}
