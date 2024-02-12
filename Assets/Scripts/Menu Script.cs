using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject journal;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MenuButtonClicked()
    {
        gameObject.SetActive(false);
        menu.SetActive(true);
    }

    public void HomeButtonClicked()
    {
        menu.SetActive(false);
        gameObject.SetActive(true);
    }

    public void JournalButtonClicked()
    {
        journal.SetActive(true);
    }
}
