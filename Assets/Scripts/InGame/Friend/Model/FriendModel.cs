﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonLib.Commons;
using UniRx;
using Thirty.Data;

public class FriendModel : UdonBehaviour
{
    private FriendData _friendData;
    public FriendData FriendData => _friendData;
}
