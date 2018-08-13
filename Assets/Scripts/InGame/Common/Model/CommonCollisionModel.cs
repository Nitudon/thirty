using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonLib.Commons;
using UniRx;
using UniRx.Triggers;
using Thirty.Enum;

[RequireComponent(typeof(Collider2D))]
public class CommonCollisionModel : UdonBehaviour 
{
    [SerializeField]
    private Collider2D _collider;

    private CollisionType _collisionType;
    public CollisionType CollisionType => _collisionType;

    private IObservable<CollisionType> _onCollisionModelEnterAsObservable;
    public IObservable<CollisionType> OnCollisionModelEnterAsObservable => _onCollisionModelEnterAsObservable;

    public void SetCollisionType(CollisionType collision)
    {
        _collisionType = collision;
    }

    public void SetObserver()
    {
        _onCollisionModelEnterAsObservable =
            _collider
                .OnTriggerEnter2DAsObservable()
                .Where(x => x != null && x.enabled)
                .Select(_ => _collisionType)
                .Publish()
                .RefCount();
    }

    public void SetCollisionEnable(bool active)
    {
        _collider.enabled = false;
    }
}
