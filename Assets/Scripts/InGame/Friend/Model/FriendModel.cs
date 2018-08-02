using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonLib.Commons;
using UniRx;

public class FriendModel : UdonBehaviour
{
    private ReactiveProperty<int> _friendCount = new ReactiveProperty<int>();
    public IReadOnlyReactiveProperty<int> FriendCount => _friendCount;

    public void UseFriend(int num)
    {
        if(_friendCount.Value > num)
        {
            _friendCount.Value -= num;
        }
        else
        {
            _friendCount.Value = 0;
        }
    }
}
