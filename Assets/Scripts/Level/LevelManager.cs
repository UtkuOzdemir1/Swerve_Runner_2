using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    [field: SerializeField] public LevelElement[] Levels { get; private set; }

    private LevelElement currentLevel;

    private GameState previousState;

    private LevelElement _previousLevel;
    public override void Initialize()
    {

    }

    public override void StateUpdate(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Loading:
                Build();
                break;
            case GameState.Idle:
                break;
            case GameState.Gameplay:
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;

        }

        previousState = gameState;
    }

    private void Build()
    {
        if (currentLevel)
            Destroy(currentLevel.gameObject);

        if(PlayerDataHandler.instance.PlayerData.Level <= Levels.Length)
            currentLevel = Instantiate(Levels[PlayerDataHandler.instance.PlayerData.Level - 1]);
        else
        {
            if(previousState == GameState.Lose)
                currentLevel = Instantiate(_previousLevel);
            else
                currentLevel = Instantiate(Levels[Random.Range(0, Levels.Length)]);
        }

        _previousLevel = currentLevel;
    }
}
