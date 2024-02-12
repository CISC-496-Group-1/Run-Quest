using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject menu;
    private bool menuOn;
    // Start is called before the first frame update
    void Start()
    {
        menuOn = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (menuOn)
        {
            menuOn = false;
            menu.SetActive(false);
        } else
        {
            menuOn = true;
            menu.SetActive(true);
        }
        
    }
}
