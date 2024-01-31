using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int HP;
    public int Speed;
    public int Damage;
    // Constructor
    public Character(int hp, int speed, int damage)
    {
        HP = hp;
        Speed = speed;
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

    // Heal method
    public void Heal(Character target, int healPoint)
    {
        target.HP += healPoint;
    }
}
