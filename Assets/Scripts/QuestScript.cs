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
        stats.addStrength(Random.Range(1, 3));
        stats.addDefense(Random.Range(1, 3));
        stats.addMagicDamage(Random.Range(1, 3));
        stats.addSpeed(Random.Range(1, 3));
        Destroy(gameObject);
        stats.updatePlayerStats();
    }
}
