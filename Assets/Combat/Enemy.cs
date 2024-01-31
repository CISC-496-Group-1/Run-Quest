using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    public int Damage;
    // Constructor
    public Enemy(int hp, int damage)
    {
        HP = hp;
        Damage = damage;
    }

    // Attack method
    public void Attack(Character target)
    {
        target.HP -= this.Damage;
        // Trigger attack animation here (later steps will cover this)
    }

    // Check if defeated
    public bool IsDefeated()
    {
        return HP <= 0;
    }
}
