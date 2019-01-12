using UnityEngine;
using Thirty.Data;
using UniRx;
using Zenject;

/// <summary>
/// プレイヤーの衝突周りのロジック
/// </summary>
public class PlayerCollisionUseCase
{
    private CommonCollisionModel _playerCollisionModel;

    public PlayerCollisionUseCase(CommonCollisionModel model)
    {
        _playerCollisionModel = model;
    }

    public Subject<BlockData> OnPlayerCollideBlock()
    {
        return InGameManager.Instance.CollisionModel.OnCollisionBlock.AddTo(_playerCollisionModel.gameObject);
    }

    public Subject<FriendData> OnPlayerCollideFriend()
    {
        return InGameManager.Instance.CollisionModel.OnCollisionFriend.AddTo(_playerCollisionModel.gameObject);
    }
}
