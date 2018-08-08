using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonLib.Commons;
using UdonLib.UI;

public class PlayerMonoView : UIMono
{
    [SerializeField]
    private Collider2D _playerCollision;
    public Collider2D PlayerCollision => _playerCollision;
}
