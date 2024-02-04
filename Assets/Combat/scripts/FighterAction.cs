using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    private GameObject hero;
    private GameObject enemy;

    [SerializeField]
    private GameObject attackPrefab;

    [SerializeField]
    private GameObject defendPrefab;

    [SerializeField]
    private Sprite faceIcon;

    private GameObject currentAttack;

    void Awake()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    public void SelectAttack(string btn)
    {
        GameObject victim = hero;
        if (tag == "Hero")
        {
            victim = enemy;
        }
        if (btn.CompareTo("Attack") == 0)
        {
            Debug.Log("Attack!");
            attackPrefab.GetComponent<AttackScript>().Attack(victim);

        }
        else if (btn.CompareTo("Defend") == 0)
        {
            Debug.Log("Defend!");
            if (tag == "Hero")
            {
                defendPrefab.GetComponent<AttackScript>().Attack(hero);
            }
            else
            {
                defendPrefab.GetComponent<AttackScript>().Attack(enemy);
            }
            
        }
        else
        {
            Debug.Log("Run");
        }
    }
}