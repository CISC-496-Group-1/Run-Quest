using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject canvas; // 引用包含Animator组件的Canvas对象
    private Animator animator; // Animator组件的引用
    private GameObject currentTeleporter;
    public float transitionTime = 1f; // 动画过渡时间
    public GameObject Image;

    void Start()
    {
        animator = canvas.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                StartCoroutine(TeleportPlayer());
            }
        }
    }

    private IEnumerator TeleportPlayer()
    {
        Image.SetActive(true);
        animator.SetTrigger("Start"); // 激活开始瞬移的动画
        yield return new WaitForSeconds(transitionTime); // 等待动画播放完成

        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position; // 更新玩家位置到瞬移目标点
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}