using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TabGroup tabgroup;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        tabgroup.OnTabSelected(this);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        tabgroup.OnTabEnter(this);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        tabgroup.OnTabExit(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        tabgroup.AddNewButton(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
