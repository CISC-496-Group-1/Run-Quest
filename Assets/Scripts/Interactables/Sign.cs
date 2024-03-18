using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogBoxText;
    public string signText;
    private bool isPlayerInSign;

    [SerializeField] private AudioSource readSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        
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






    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInSign)
        {
            if (!dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(true);
                StartCoroutine(TypeSentence(signText));
                readSoundEffect.Play();
            }
            else
            {
                dialogBox.SetActive(false);
                // Other code to handle the end of the dialogue, if any
            }
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isPlayerInSign = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isPlayerInSign = false;
            dialogBox.SetActive(false);
        }
    }
}
