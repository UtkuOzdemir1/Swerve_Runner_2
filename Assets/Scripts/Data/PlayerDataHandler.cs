using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataHandler : MonoSingleton<PlayerDataHandler>
{
    public PlayerData PlayerData { get; private set; }

    public event Action<int> OnCoinUpdate;
    public event Action<int> OnLevelUpdate;

    public override void Initialize()
    {
        if (PlayerPrefs.HasKey("Coin") && PlayerPrefs.HasKey("Level"))
            PlayerData = new PlayerData(PlayerPrefs.GetInt("Level"), PlayerPrefs.GetInt("Coin"));
        else
        {
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.SetInt("Coin", 0);
            PlayerData = new PlayerData(PlayerPrefs.GetInt("Level"), PlayerPrefs.GetInt("Coin"));
        }
    }

    public void CoinUpdate(int amount)
    {
        PlayerData.Coin += amount;
        PlayerPrefs.SetInt("Coin", PlayerData.Coin);
        OnCoinUpdate?.Invoke(PlayerData.Coin);
    }
    public void PlayerProgress()
    {
        PlayerData.Level++;
        PlayerPrefs.SetInt("Level", PlayerData.Level);
        OnLevelUpdate?.Invoke(PlayerData.Level);
    }

    

    public override void StateUpdate(GameState state)
    {
    }
}

public class PlayerData
{
    public int Level;
    public int Coin;

    public PlayerData(int initialLevel, int initialCoin)
    {
        Level = initialLevel;
        Coin = initialCoin;
    }
}

