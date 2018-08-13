using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonLib.Commons;

public class FriendPresenter : InitializableMono
{
    [SerializeField]
    private FriendView _friendView;

    private CommonCollisionModel _collisionModel;

    public override void Initialize()
    {
        _collisionModel.SetObserver();
    }
}
