using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UdonLib.Commons;

public class PlayerPresenter : InitializableMono
{
    [Inject]

    [SerializeField]
    private PlayerMonoView _view;

    [SerializeField]
    private PlayerInputHandler _inputHandler;

    [SerializeField]
    private CommonCollisionModel _collisionModel;

    private PlayerMoveUseCase _movementUseCase;
    private PlayerCollisionUseCase _collisionUseCase;

    private CompositeDisposable _playerDisposable;

    public override void Initialize()
    {
        _playerDisposable = new CompositeDisposable();

        _inputHandler.Initialize();    

        _movementUseCase = new PlayerMoveUseCase(_inputHandler);
        _collisionUseCase = new PlayerCollisionUseCase(_collisionModel);

        _collisionModel.SetObserver();

        Bind();
    }

    private void Bind()
    {
        _movementUseCase.BindMovement(_view.RectTransform, _playerDisposable);

        _collisionUseCase.OnPlayerCollideBlock().Subscribe().AddTo(_playerDisposable);
    }
}
