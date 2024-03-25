using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public static Vector3 playerPositionBeforeSceneChange;
    public GameObject dialogBox; 
    public Text dialogBoxText; 
    public string[] dialogues; 
    public string sceneToLoad; 
    public float typingSpeed = 0.02f;
    public GameObject Player;
    public GameObject canvas;
    public GameObject Image;
    public GameObject fightButton;
    public GameObject escapeButton;

    private Animator transition;
    private Queue<string> dialogueQueue = new Queue<string>(); 
    private bool isDialogueActive = false; 

    void Awake() {
        escapeButton.SetActive(false);
        dialogBox.SetActive(false); 
        fightButton.SetActive(false);
        foreach (string dialogue in dialogues) {
            dialogueQueue.Enqueue(dialogue); 
        }
        transition = canvas.GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !isDialogueActive) {
            playerPositionBeforeSceneChange = other.transform.position; 
            StartCoroutine(BeginDialogue());
        }
    }

    private IEnumerator BeginDialogue() {
        isDialogueActive = true;
        dialogBox.SetActive(true);

        while (dialogueQueue.Count > 0) {
            string sentence = dialogueQueue.Dequeue();
            yield return StartCoroutine(TypeSentence(sentence)); 
        }

        fightButton.SetActive(true);
        escapeButton.SetActive(true);
        isDialogueActive = false;
    }

    public void OnFightButtonClicked() {
        fightButton.SetActive(false);
        Image.SetActive(true);
        transition.SetTrigger("Start");
        StartCoroutine(TransitionToScene());
    }

    
    private IEnumerator TypeSentence(string sentence) {
        dialogBoxText.text = ""; 
        foreach (char letter in sentence.ToCharArray()) {
            dialogBoxText.text += letter; 
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private IEnumerator TransitionToScene() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ExitDialogue() {
        StopAllCoroutines(); // Halts the ongoing typing coroutine
        dialogueQueue.Clear(); // Empties the queue of pending dialogues
        dialogBox.SetActive(false); // Hides the dialogue box
        escapeButton.SetActive(false); // Disables the escape button
        fightButton.SetActive(false); // Optionally hides the fight button, if relevant to context
        isDialogueActive = false; // Resets dialogue activity flag
    }

}