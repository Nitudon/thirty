using UnityEngine;
using System.Collections;
using UniRx;
using Thirty.Data;

public class PlayerFriendsUseCase
{
    private FriendCollectionModel _friendModel;

    public PlayerFriendsUseCase(FriendCollectionModel model)
    {
        _friendModel = model;
    }

    public ReactiveProperty<int> FriendCount()
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
}
