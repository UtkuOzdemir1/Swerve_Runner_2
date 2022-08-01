using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPage : PageBase
{
    [SerializeField] float waitTime;

    WaitForSeconds _wait;
    public override void Activate(bool condition)
    {
        _wait = new WaitForSeconds(waitTime);
        base.Activate(condition);
        if(condition)
            StartCoroutine(LoadingTime());
    }

    public void PlayGame()
    {
        GameManager.instance.StateUpdate(GameState.Idle);       
    }

    public void QuitGame()
    {
        GameManager.instance.StateUpdate(GameState.Loading);
    }
    IEnumerator LoadingTime()
    {
        yield return _wait;
        PlayGame();
    }

}
