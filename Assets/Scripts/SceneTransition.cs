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

    private Animator transition;
    private Queue<string> dialogueQueue = new Queue<string>(); 
    private bool isDialogueActive = false; 

    void Awake() {
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
        isDialogueActive = false;
    }

    public void OnFightButtonClicked() {
        Debug.Log("Button clicked!");
        fightButton.SetActive(false); // Disable the button to prevent multiple clicks.
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


}