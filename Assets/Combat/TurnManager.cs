using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Hero playerHero;
    public Enemy aiEnemy;

    private bool isPlayerTurn;

    void Start()
    {
        // Decide who starts first (for example, based on Speed)
        isPlayerTurn = (playerHero.Speed >= aiEnemy.Speed);

        StartTurn();
    }

    void StartTurn()
    {
        if (isPlayerTurn)
        {
            // Player's turn: Enable player input or UI controls
            EnablePlayerInput();
        }
        else
        {
            // AI's turn: Call AI decision-making function
            aiEnemy.ChooseAction(playerHero);

            // End AI Turn after action is performed
            EndTurn();
        }
    }

    public void EndTurn()
    {
        // Check if the game has ended
        if (playerHero.IsDefeated() || aiEnemy.IsDefeated())
        {
            GameOver(); // Implement game over logic
            return;
        }

        // Switch turn
        isPlayerTurn = !isPlayerTurn;

        // Start next turn
        Invoke(nameof(StartTurn), 1.0f); // Delay for turn transition
    }

    void EnablePlayerInput()
    {
        // Enable UI buttons or other input methods for the player to take action
        // Player actions should trigger functions that ultimately call EndTurn()
    }

    void GameOver()
    {
        // Implement what happens when the game is over (display winner, restart, etc.)
    }
}
