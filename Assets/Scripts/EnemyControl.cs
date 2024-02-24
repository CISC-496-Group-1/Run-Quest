using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    
    void Start() 
    {
        if (GameManager.Instance.IsEnemyDefeated("giant")) {
            var monster = GameObject.FindWithTag("Monster"); // Assuming the Monster has the tag "Enemy"
            if (monster != null) {
                Destroy(monster);
            }
        }
    }
}