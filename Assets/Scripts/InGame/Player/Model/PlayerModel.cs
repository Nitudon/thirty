using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonLib.Commons;


public class PlayerModel : UdonBehaviour
{
    [SerializeField]
    private Collider2D _playerCollision;
    public Collider2D PlayerCollision => _playerCollision;

    private readonly FriendCollectionModel _friends;


}
