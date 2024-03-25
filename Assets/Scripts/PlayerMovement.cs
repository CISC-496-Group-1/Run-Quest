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

    public bool moving;
    public bool ableToMove = true;
    private Animator animator;

    private LogScript log;
    private PlayerStats stats;

    private void Start()
    {
        // Initialize the distance text.
        UpdateDistanceText();
        currentTravelDistance = PlayerPrefs.GetFloat("PlayerDistance", 0f);

        if (SceneTransition.playerPositionBeforeSceneChange != Vector3.zero)
        {
            transform.position = SceneTransition.playerPositionBeforeSceneChange;
            SceneTransition.playerPositionBeforeSceneChange = Vector3.zero; // Reset the position
        }


        log = GetComponent<LogScript>();
        stats = GetComponent<PlayerStats>();

        
    }

    private void OnDisable()
    {
        //Save distance before scene switching
        PlayerPrefs.SetFloat("PlayerDistance", currentTravelDistance);
        PlayerPrefs.Save();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
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

        if (ableToMove)
        {
            if (moving && (Vector2)transform.position != lastClickedPos && currentTravelDistance > 0.001)
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
                if (lastClickedPos.x - transform.position.x != 0 || lastClickedPos.y - transform.position.y != 0)
                {
                    animator.SetFloat("X", lastClickedPos.x - transform.position.x);
                    animator.SetFloat("Y", lastClickedPos.y - transform.position.y);

                    animator.SetBool("isWalking", true);
                }
                else { animator.SetBool("isWalking", false); }



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
                animator.SetBool("isWalking", false);
            }
        }
    }

    // Call these methods to add travel distance
    public void AddDistance(float amount)
    {
        currentTravelDistance += amount;
        if (currentTravelDistance > maxTravelDistance)
            currentTravelDistance = maxTravelDistance;

        if (amount == 1.0f)
        {
            log.CreateNewLog(1);
            stats.GenerateStats(1, 3);

        }
        else if (amount == 2.0f)
        {
            log.CreateNewLog(2);
            stats.GenerateStats(3, 5);
        }
        else
        {
            log.CreateNewLog(3);
            stats.GenerateStats(5, 7);
        }

        Debug.Log("Distance added. Current distance: " + currentTravelDistance);
    }

    private void UpdateDistanceText()
    {
        if (distanceText != null)
            distanceText.text = "Distance: " + currentTravelDistance.ToString("F2") + " KM"; // Format the distance display
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        moving = false;
    }
}







