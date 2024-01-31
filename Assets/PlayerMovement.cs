using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    
    Vector2 lastClickedPos;

    bool moving;
    bool mouseDown = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        moving = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }
        if (mouseDown)
        {
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }

        if (moving && (Vector2)transform.position != lastClickedPos)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);

        }
        else
        {
            moving = false;
        }
    }
}












/* private void Update()
{

    if (Input.GetMouseButtonDown(0))
    {
        lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moving = true;
    }

    if (moving && (Vector2)transform.position != lastClickedPos)
    {
        float step = speed * Time.deltaTime;

        

    }
    else
    {
        moving = false;
    }
}

}*/