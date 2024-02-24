using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public static GameManager Instance;

    private HashSet<string> defeatedEnemies = new HashSet<string>();

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }

    public void DefeatEnemy(string enemyName) {
        defeatedEnemies.Add(enemyName);
    }

    public bool IsEnemyDefeated(string enemyName) {
        return defeatedEnemies.Contains(enemyName);
    }
}