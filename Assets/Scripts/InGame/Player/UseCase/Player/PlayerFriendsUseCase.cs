using UnityEngine;
using System.Collections;
using UniRx;
using Thirty.Data;

/// <summary>
/// プレイヤーの仲間周りのロジック
/// </summary>
public class PlayerFriendsUseCase
{
    private FriendCollectionModel _friendModel;

    public PlayerFriendsUseCase(FriendCollectionModel model)
    {
        _friendModel = model;
    }

    public IReadOnlyReactiveProperty<int> FriendCount()
    {
        return
            _friendModel
                .FriendList
                .ObserveCountChanged()
                .ToReactiveProperty();
    }

    public void BattleFriend(BlockData battleCost)
    {
        _friendModel.DecreaseFriend(battleCost.Count);
    }

    public void GetFriend(FriendData friend)
    {
        _friendModel.AddFriend(friend);
    }
}
