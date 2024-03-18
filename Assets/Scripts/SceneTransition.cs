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

    private Animator transition;
    private Queue<string> dialogueQueue = new Queue<string>(); 
    private bool isDialogueActive = false; 

    void Awake() {
        dialogBox.SetActive(false); 
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
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E)); 
        }

        dialogBox.SetActive(false); 
        isDialogueActive = false;
        Image.SetActive(true);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
    }

    private IEnumerator TypeSentence(string sentence) {
        dialogBoxText.text = ""; 
        foreach (char letter in sentence.ToCharArray()) {
            dialogBoxText.text += letter; 
            yield return new WaitForSeconds(typingSpeed);
        }
    }

}