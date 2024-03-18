using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject canvas; // ????Animator???Canvas??
    private Animator animator; // Animator?????
    private GameObject currentTeleporter;
    public float transitionTime = 1f; // ??????
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
        animator.SetTrigger("Start"); // ?????????
        yield return new WaitForSeconds(transitionTime); // ????????
        
        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position; // ????????????
        Image.SetActive(false);
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