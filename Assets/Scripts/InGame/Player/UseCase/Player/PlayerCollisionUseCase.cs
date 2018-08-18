using UnityEngine;
using Thirty.Data;
using UniRx;
using Zenject;

/// <summary>
/// プレイヤーの衝突周りのロジック
/// </summary>
public class PlayerCollisionUseCase
{
    [Inject]
    private InGameCollisionModel _inGameCollisionModel;

    private CommonCollisionModel _playerCollisionModel;

    public PlayerCollisionUseCase(CommonCollisionModel model)
    {
        _playerCollisionModel = model;
    }

    public Subject<BlockData> OnPlayerCollideBlock()
    {
        return _inGameCollisionModel.OnCollisionBlock.AddTo(_playerCollisionModel.gameObject);
    }

    public Subject<FriendData> OnPlayerCollideFriend()
    {
        return _inGameCollisionModel.OnCollisionFriend.AddTo(_playerCollisionModel.gameObject);
    }
}
