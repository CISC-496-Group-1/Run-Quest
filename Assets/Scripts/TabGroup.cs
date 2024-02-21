using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> buttons;
   
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

    }

    public void OnTabExit ( TabButton button) {
        
    }

    public void OnTabSelected (TabButton button )
    {

    }
}
