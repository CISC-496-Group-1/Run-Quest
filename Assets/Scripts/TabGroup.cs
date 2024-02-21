using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TabGroup : MonoBehaviour
{
    public List<TabButton> buttons;

    public Color hoverColor;
    public Color selectedColor;
    public Color idleColor;

    public void AddNewButton(TabButton button)
    {
        if (buttons == null)
        {
            buttons = new List<TabButton>();
        }

        buttons.Add(button);
    }

    public void OnTabEnter( TabButton button)
    {
        ResetColors();
        button.GetComponent<Image>().color = hoverColor;
    }

    public void OnTabExit ( TabButton button) 
    {
        ResetColors();
    }

    public void OnTabSelected (TabButton button )
    {
        ResetColors();
        button.GetComponent<Image>().color = selectedColor;
    }

    public void ResetColors()
    {
        foreach (TabButton button in buttons)
        {
            button.GetComponent<Image>().color = idleColor;
        }
    }
}
