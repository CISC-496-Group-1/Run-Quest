using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float maxTravelDistance = 10f; // Maximum distance the player can travel
    private float currentTravelDistance; // Current available distance for travel

    Vector2 lastClickedPos;

    bool moving;

    private void Start()
    {
        // Initialize the current travel distance to the max at the start
        currentTravelDistance = maxTravelDistance;
    }


    private void Update()
    {
        // Check if the mouse is not over a UI element
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (currentTravelDistance > 0)
            {
                lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                moving = true;
            }
        }

        if (moving && (Vector2)transform.position != lastClickedPos)
        {
            float step = speed * Time.deltaTime;

            // Calculate the distance that will be moved this frame
            float distanceToMove = Vector2.Distance(transform.position, lastClickedPos);
            if (step > distanceToMove)
            {
                step = distanceToMove; // Ensure we don't move beyond the target
            }

            if (step > currentTravelDistance)
            {
                step = currentTravelDistance; // Ensure we don't move beyond the available distance
                moving = false; // Stop moving if we have reached the travel limit
            }

            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);

            // Decrease the available travel distance
            currentTravelDistance -= step;

            if (currentTravelDistance <= 0)
            {
                moving = false;
                currentTravelDistance = 0;
            }
        }
        else
        {
            moving = false;
        }
    }

    // Call these methods to add travel distance
    public void ReduceDistance(float amount)
    {
        currentTravelDistance -= amount;
        if (currentTravelDistance < 0)
            currentTravelDistance = 0;

        Debug.Log("Distance reduced. Current distance: " + currentTravelDistance);
    }

    // Call this method to replenish the total distance
    public void ReplenishDistance()
    {
        currentTravelDistance = maxTravelDistance;
        Debug.Log("Distance replenished. Current distance: " + currentTravelDistance);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        moving = false;
    }
}







