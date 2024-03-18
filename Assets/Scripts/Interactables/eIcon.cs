using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEIcon : MonoBehaviour
{
    public GameObject eIcon; // 指向你的"E"图标的引用
    public GameObject player;

    // 当玩家角色进入2D触发器区域时调用
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 确保只有玩家可以触发事件
        {
            eIcon.SetActive(true); // 显示"E"图标
            eIcon.transform.position = player.transform.position;



        }
    }

    // 当玩家角色离开2D触发器区域时调用
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 确保只有玩家可以触发事件
        {
            eIcon.SetActive(false); // 隐藏"E"图标
        }
    }
}

