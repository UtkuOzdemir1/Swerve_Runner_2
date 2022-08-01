using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePage : PageBase
{
    public void PlayGame()
    {
        GameManager.instance.StateUpdate(GameState.Gameplay);
    }
    public void QuitGame()
    {
        GameManager.instance.StateUpdate(GameState.Loading);
    }
}
