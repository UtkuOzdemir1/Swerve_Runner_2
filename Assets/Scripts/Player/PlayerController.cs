using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoSingleton<PlayerController>
{
    [SerializeField] PlayerMovementHandler movement;
    [SerializeField] Animator _animator;
    
    GameState _gameState;

    public override void Initialize()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Obstacle":
                GameManager.instance.StateUpdate(GameState.Lose);
                break;
            case "Coin":
                ICollectable mushroom = other.GetComponent<ICollectable>();
                mushroom.OnCollect();
                PlayerDataHandler.instance.CoinUpdate(1);
                GameObject particle = ObjectPool.instance.GetPooledObject();
                
                particle.transform.position = transform.position;
                particle.SetActive(true);
                break;
            case "LevelCollider":
                GameManager.instance.StateUpdate(GameState.Win);
                break;
        }
    }




    private void Update()
    {
        if (_gameState != GameState.Gameplay) return;
        movement.CustomUpdate();
    }
    private void SetDefault()
    {
        transform.position = Vector3.zero;
    }


    public override void StateUpdate(GameState state)
    {
        _gameState = state;
        switch (state)
        {
            case GameState.Loading:
                SetDefault();
                break;
            case GameState.Idle:
                _animator.Play("Idle");
                break;
            case GameState.Gameplay:
                _animator.Play("Run");
                break;
            case GameState.Win:
                _animator.Play("Win");
                break;
            case GameState.Lose:
                _animator.Play("Lose");
                break;
        }
    }
}
