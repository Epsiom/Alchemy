using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enum of all different game states.
/// P1TurnPlanningLocked and P2TurnPlanningLocked describe only one player having locked his turn while the other is still planning.
/// </summary>
public enum GameState
{
    GameStart,
    TurnStart,
    P1TurnPlanningLocked,
    P2TurnPlanningLocked,
    TurnExecution,
    P1Victory,
    P2Victory
}


/// <summary>
/// Handles the game states and sends events each time it changes
/// See: https://www.youtube.com/watch?v=4I0vonyqMi8
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.GameStart);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState) {
            case GameState.GameStart:
                HandleGameStart();
                break;
            case GameState.TurnStart:
                HandleTurnStart();
                break;
            case GameState.P1TurnPlanningLocked:
                break;
            case GameState.P2TurnPlanningLocked:
                break;
            case GameState.TurnExecution:
                break;
            case GameState.P1Victory:
                break;
            case GameState.P2Victory:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);  // Sends an event indicating the state changed. The '?.' avoids a null error if noone is subscribed to it
    }

    public void HandleGameStart()
    {
        //TODO
    }

    public void HandleTurnStart()
    {
        //TODO
    }
}
