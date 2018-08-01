using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonLib.Commons;
using Thirty.Enum;

[RequireComponent(typeof(Collider2D))]
public class CommonCollisionModel : UdonBehaviour 
{
    private CollisionType _collisionType;
    public CollisionType CollisionType => _collisionType;

    public void SetCollisionType(CollisionType collision)
    {
        _collisionType = collision;
    }
	
}
