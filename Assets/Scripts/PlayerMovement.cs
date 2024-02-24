using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float maxTravelDistance = 10f; // Maximum distance the player can travel
    public float currentTravelDistance; // Current available distance for travel

    public Text distanceText; 

    Vector2 lastClickedPos;

    bool moving;

    private LogScript log;
    private PlayerStats stats;

    private void Start()
    {
        // Initialize the distance text.
        UpdateDistanceText();
        log = GetComponent<LogScript>();
        stats = GetComponent<PlayerStats>();
    }


    private void Update()
    {
        UpdateDistanceText();

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
            currentTravelDistance -= step * 0.25f;

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
    public void AddDistance(float amount)
    {
        currentTravelDistance += amount;
        if (currentTravelDistance > maxTravelDistance)
            currentTravelDistance = maxTravelDistance;

        Debug.Log("Distance added. Current distance: " + currentTravelDistance);

       if (amount == 1.0f)
        {
            log.CreateNewLog(1);
            stats.GenerateStats(1, 3);
            
        } else if (amount == 2.0f) {
            log.CreateNewLog(2);
            stats.GenerateStats(3, 5);
        } else
        {
            log.CreateNewLog(3);
            stats.GenerateStats(5, 7);
        }
    }

    private void UpdateDistanceText()
    {
        if (distanceText != null)
            distanceText.text = "Distance: " + currentTravelDistance.ToString("F2") + " KM"; // Format the distance display
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        moving = false;
    }
}







