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
        int maxChars = 200; // Example max char count that fits in the dialog box
        for (int i = 0; i < sentence.Length; i += maxChars)
        {
            // Determine the substring to display
            string segment = sentence.Substring(i, Math.Min(maxChars, sentence.Length - i));
            dialogBoxText.text = ""; // Clear previous text
            foreach (char letter in segment.ToCharArray())
            {
                dialogBoxText.text += letter;
                yield return new WaitForSeconds(0.05f); // Adjust typing speed as needed
            }
            
            // Wait for mouse click to continue if not at the end of the sentence
            if (i + maxChars < sentence.Length)
            {
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0)); // Wait for left mouse click
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isPlayerInSign)
        {
            if(!dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(true);
                StartCoroutine(TypeSentence(signText));
                readSoundEffect.Play();
            }
            else
            {
                dialogBox.SetActive(false);
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
