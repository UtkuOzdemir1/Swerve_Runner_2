using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePage : PageBase
{
    public void PlayGame()
    {
        GameManager.instance.StateUpdate(GameState.Loading);
    }
    public void QuitGame()
    {
        GameManager.instance.StateUpdate(GameState.Loading);
    }
}
