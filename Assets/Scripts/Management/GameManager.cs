using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] MonoSingleton[] elements;

    GameState _gameState;

    public override void Initialize()
    {
        foreach (var element in elements)
            element.Initialize();
    }

    private void Start()
    {
        StateUpdate(GameState.Loading);
    }

    public override void StateUpdate(GameState state)
    {
        _gameState = state;

        foreach (var element in elements)
            element.StateUpdate(state);

        switch (state)
        {
            case GameState.Loading:
                // SDK varsa, SDK'ya mesaj yolluyosun;
                // ElephantSDK.LevelLoading(PlayerDataHandler.PlayerData.Level);
                break;
            case GameState.Idle:
                break;
            case GameState.Gameplay:
                // ElephantSDK.LevelStarted(PlayerDataHandler.PlayerData.Level);
                break;
            case GameState.Lose:
                // ElephantSDK.LevelFailed(PlayerDataHandler.PlayerData.Level);
                break;
            case GameState.Win:
                // ElephantSDK.LevelCompleted(PlayerDataHandler.PlayerData.Level);
                break;
        }
    }
}

public enum GameState
{
    Loading,
    Idle,
    Gameplay,
    Lose,
    Win
}
