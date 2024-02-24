using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    public JournalSim journal;
    void Start()
    {
        journal.AddQuest(gameObject);
    }

    public void completeQuest()
    {
        PlayerStats stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        stats.GenerateStats(1, 3);
        Destroy(gameObject);
        stats.updatePlayerStats();
    }
}
