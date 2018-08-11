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

    [SerializeField]
    private CommonCollisionModel _collisionModel;

    public override void Initialize()
    {
        _inputHandler.Initialize();    

        _movementUseCase = new PlayerMoveUseCase(_inputHandler);

        _collisionModel.SetObserver();

        Bind();
    }

    private void Bind()
    {
        _movementUseCase.BindMovement(_view.RectTransform);
    }
}
