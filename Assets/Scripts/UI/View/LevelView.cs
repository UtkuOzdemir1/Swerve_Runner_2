using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelView : ViewBase<int>
{
    [SerializeField] string prefix, postfix;
    [SerializeField] TextMeshProUGUI levelText;

    public override void Initialize()
    {
        base.Initialize();
        levelText.text = $"{prefix} 1 {postfix}";
        PlayerDataHandler.instance.OnLevelUpdate += OnLevelIncrease;
    }
    public override void UpdateView(int updatedData)
    {
        levelText.text = $"{prefix} {updatedData} {postfix}";
    }
    public void OnLevelIncrease(int level)
    {
        string levelText = level.ToString();
    }
}
