using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<Character> characters;

    private int currentCharacterIndex = 0;

    void Start()
    {
        // Sort characters by Speed
        characters.Sort((c1, c2) => c2.Speed.CompareTo(c1.Speed));
        StartTurn();
    }

    void StartTurn()
    {
        if (CheckForEndOfCombat())
        {
            // End the combat
            return;
        }

        Character currentCharacter = characters[currentCharacterIndex];
        currentCharacter.Attack(characters[0]);

        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Count;
        Invoke(nameof(StartTurn), 1.0f); // Wait for 1 second between turns
    }

    bool CheckForEndOfCombat()
    {
        foreach (var character in characters)
        {
            if (character.IsDefeated())
            {
                Debug.Log("Combat Ended");
                return true;
            }
        }
        return false;
    }
}
