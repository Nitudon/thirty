﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonLib.Commons;
using UniRx;

/// <summary>
/// プレイヤーのモデル
/// </summary>
public class PlayerModel : IInitializable
{
    private FriendCollectionModel _friendModel;
    public FriendCollectionModel FriendModel => _friendModel;

    public void Initialize()
    {
        _friendModel = new FriendCollectionModel();
    }
}
