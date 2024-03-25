using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    public JournalSim journal;
    private PlayerStats stats;
    void Start()
    {
        journal.AddQuest(gameObject);
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    public void completeQuest()
    {
        PlayerStats stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        stats.GenerateStats(1, 3);
        Destroy(gameObject);
        stats.UpdatePlayerStats();
    }
}
