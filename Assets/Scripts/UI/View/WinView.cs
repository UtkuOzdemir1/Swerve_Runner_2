using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class WinView : ViewBase
{
    public override void Activate(bool condition)
    {
        base.Activate(condition);
        if (condition)
            transform.DOLocalMoveX(0, 1f);
        //else
        //    transform.localPosition = new Vector3(-1000, transform.localPosition.y, 0);
    }
    public void OnNextLevel()
    {
        PlayerDataHandler.instance.PlayerProgress();
        GameManager.instance.StateUpdate(GameState.Loading);

    }


}
