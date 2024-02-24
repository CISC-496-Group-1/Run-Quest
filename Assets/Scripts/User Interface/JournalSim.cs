using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JournalSim : MonoBehaviour, IPointerClickHandler
{
    public GameObject player;
    public List<GameObject> quests;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    void Start()
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
    }

    public void AddQuest(GameObject quest) {
        quests.Add(quest);
    }
}
