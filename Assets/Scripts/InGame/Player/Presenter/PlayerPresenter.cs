using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonLib.Commons;

public class PlayerPresenter : InitializableMono
{
    [SerializeField]
    private PlayerMonoView _view;

    [SerializeField]
    private PlayerInputHandler _inputHandler;

    private PlayerMoveUseCase _movementUseCase;
    private PlayerCollisionUseCase _collisionUseCase;

    public override void Initialize()
    {
        _inputHandler.Initialize();    

        _movementUseCase = new PlayerMoveUseCase(_inputHandler);
        _collisionUseCase = new PlayerCollisionUseCase(_view.PlayerCollision);

        Bind();
    }

    private void Bind()
    {
        _movementUseCase.BindMovement(_view.RectTransform);
        _collisionUseCase.SetObserver();
    }
}
