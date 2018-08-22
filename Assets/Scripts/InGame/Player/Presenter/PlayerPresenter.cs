using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UdonLib.Commons;
using Zenject;

/// <summary>
/// Playerのロジックプレゼンター
/// </summary>
public class PlayerPresenter : InitializableMono
{
    [Inject]
    private InGameRuleModel _inGameRuleModel;

    [SerializeField]
    private PlayerMonoView _view;

    [SerializeField]
    private PlayerInputHandler _inputHandler;

    [SerializeField]
    private CommonCollisionModel _collisionModel;

    private FriendCollectionModel _friendCollectionModel;

    private PlayerMoveUseCase _movementUseCase;
    private PlayerCollisionUseCase _collisionUseCase;
    private PlayerFriendsUseCase _friendUseCase;

    private CompositeDisposable _playerDisposable;

    public override void Initialize()
    {
        _playerDisposable = new CompositeDisposable();

        _inputHandler.Initialize();

        _friendCollectionModel = new FriendCollectionModel();

        _movementUseCase = new PlayerMoveUseCase(_inputHandler);
        _collisionUseCase = new PlayerCollisionUseCase(_collisionModel);
        _friendUseCase = new PlayerFriendsUseCase(_friendCollectionModel);
        
        _collisionModel.SetObserver();

        Bind();
    }

    private void Bind()
    {
        _movementUseCase.BindMovement(_view.RectTransform);

        _collisionUseCase
            .OnPlayerCollideBlock()
            .Subscribe(_friendUseCase.BattleFriend)
            .AddTo(_playerDisposable);

        _collisionUseCase
            .OnPlayerCollideFriend()
            .Subscribe(_friendUseCase.GetFriend)
            .AddTo(_playerDisposable);

        _friendUseCase
            .FriendCount()
            .First(count => count <= 0)
            .Subscribe(_ => _inGameRuleModel.NotifyEndGame())
            .AddTo(_playerDisposable);
    }
}
