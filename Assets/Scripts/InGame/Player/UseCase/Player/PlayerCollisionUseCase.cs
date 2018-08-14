using UnityEngine;
using UniRx;
using Zenject;

public class PlayerCollisionUseCase
{
    [Inject]
    private InGameCollisionModel _inGameCollisionModel;
    private CommonCollisionModel _playerCollisionModel;

    private CompositeDisposable _collisionDisposable;

    public PlayerCollisionUseCase(CommonCollisionModel model)
    {
        _playerCollisionModel = model;
    }

    public void BindCollision()
    {
        
    }
}
