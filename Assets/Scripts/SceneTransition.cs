using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public static Vector3 playerPositionBeforeSceneChange;
    public GameObject dialogBox; // 对话框UI
    public Text dialogBoxText; // 对话框文本组件
    public string[] dialogues; // 在Inspector中直接输入的对话文本数组
    public string sceneToLoad; // 要加载的场景名称
    public float typingSpeed = 0.02f; // 文字打字机效果的速度

    private Queue<string> dialogueQueue = new Queue<string>(); // 存储对话队列
    private bool isDialogueActive = false; // 对话是否进行中的标志

    void Awake() {
        dialogBox.SetActive(false); // 初始设置对话框不可见
        foreach (string dialogue in dialogues) {
            dialogueQueue.Enqueue(dialogue); // 将对话文本添加到队列中
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !isDialogueActive) {
            playerPositionBeforeSceneChange = other.transform.position; // 保存玩家位置
            StartCoroutine(BeginDialogue()); // 开始对话
        }
    }

    private IEnumerator BeginDialogue() {
        isDialogueActive = true;
        dialogBox.SetActive(true);

        while (dialogueQueue.Count > 0) {
            string sentence = dialogueQueue.Dequeue();
            yield return StartCoroutine(TypeSentence(sentence)); // 显示一句对话
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E)); // 等待玩家按下E键来继续
        }

        dialogBox.SetActive(false); // 所有对话显示完毕，隐藏对话框
        isDialogueActive = false;
        SceneManager.LoadScene(sceneToLoad); // 加载下一个场景
    }

    private IEnumerator TypeSentence(string sentence) {
        dialogBoxText.text = ""; // 清空文本
        foreach (char letter in sentence.ToCharArray()) {
            dialogBoxText.text += letter; // 逐字显示
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}