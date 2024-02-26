using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    
    void Start() 
    {
        if (GameManager.Instance.IsEnemyDefeated("giant"))
        {
            var monster = GameObject.FindWithTag("Monster"); // Assuming the Monster has the tag "Enemy"
            if (monster != null)
            {
                Destroy(monster);
            }
        }

        if (GameManager.Instance.IsEnemyDefeated("ghost"))
        {
            var ghost = GameObject.FindWithTag("Ghost"); // Assuming the Monster has the tag "Ghost"
            if (ghost != null)
            {
                Destroy(ghost);
            }
        }

        if (GameManager.Instance.IsEnemyDefeated("boar"))
        {
            var boar = GameObject.FindWithTag("Boar"); // Assuming the Monster has the tag "Ghost"
            if ( boar!= null)
            {
                Destroy(boar);
            }
        }

        if (GameManager.Instance.IsEnemyDefeated("squid"))
        {
            var squid = GameObject.FindWithTag("Squid"); // Assuming the Monster has the tag "Ghost"
            if ( squid!= null)
            {
                Destroy(squid);
            }
        }

        if (GameManager.Instance.IsEnemyDefeated("yeti"))
        {
            var yeti = GameObject.FindWithTag("Yeti"); // Assuming the Monster has the tag "Ghost"
            if ( yeti != null)
            {
                Destroy(yeti);
            }
        }





    }
}