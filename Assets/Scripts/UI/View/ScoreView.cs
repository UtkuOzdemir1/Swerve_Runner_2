using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreView : ViewBase<int>
{
    [SerializeField] string prefix, postfix;
    [SerializeField] TextMeshProUGUI scoreText;


    public override void Initialize()
    {
        base.Initialize();
        scoreText.text = $"{prefix} {PlayerDataHandler.instance.PlayerData.Coin} {postfix}";
        PlayerDataHandler.instance.OnCoinUpdate += UpdateView;
    }

    public override void UpdateView(int updatedData)
    {
        scoreText.text = $"{prefix} {updatedData} {postfix}";
    }
}
