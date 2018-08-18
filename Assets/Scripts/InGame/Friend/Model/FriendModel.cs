using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonLib.Commons;
using UniRx;
using Thirty.Data;

/// <summary>
/// 仲間のモデル
/// </summary>
public class FriendModel : UdonBehaviour
{
    private FriendData _friendData;
    public FriendData FriendData => _friendData;
}
