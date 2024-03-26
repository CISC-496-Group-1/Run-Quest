using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Chest : MonoBehaviour
{
    private bool isPlayerInChest;
    [SerializeField] GameObject Item;
    public Inventory i;
    public PlayerMovement p;
    
    public GameObject dialogBox;
    public Text dialogBoxText;
    public string signText;

    [SerializeField] private AudioSource readSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        i = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    IEnumerator TypeSentence(string sentence)
    {
        // Display the entire block of text immediately
        dialogBoxText.text = sentence;

        // Check if the entire text fits within the dialog box or if we need pagination
        int maxChars = 200; // Example max char count that fits in the dialog box
        if (sentence.Length > maxChars)
        {
            // Determine how many pages we have
            int numberOfPages = Mathf.CeilToInt((float)sentence.Length / maxChars);
            for (int page = 1; page < numberOfPages; page++)
            {
                // Wait for mouse click to continue to the next page
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                // Display the next segment of text
                string segment = sentence.Substring(page * maxChars, Math.Min(maxChars, sentence.Length - page * maxChars));
                dialogBoxText.text = segment;
            }
        }

        // Optionally, wait for one final click before closing the dialogue box
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInChest)
        {
            p.ableToMove = false;
            if (!dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(true);
                StartCoroutine(TypeSentence(signText));
                readSoundEffect.Play();
            }
            else
            {
                dialogBox.SetActive(false);
                p.ableToMove=true;
                Destroy(transform.parent.gameObject);
            }
       
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInChest = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInChest = false;
        }
    }


}
