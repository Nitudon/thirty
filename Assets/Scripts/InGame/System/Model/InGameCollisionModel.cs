using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonLib.Commons;
using UniRx;
using Thirty.Data;

public class InGameCollisionModel : InitializableMono
{
    public Subject<FriendData> OnCollisionFriend;
    public Subject<BlockData> OnCollisionBlock;

    public override void Initialize()
    {
        OnCollisionFriend = new Subject<FriendData>();
        OnCollisionBlock = new Subject<BlockData>();
    }
}
