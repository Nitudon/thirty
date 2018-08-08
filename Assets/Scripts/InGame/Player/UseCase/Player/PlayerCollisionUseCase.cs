using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonLib.Commons;
using UniRx;
using UniRx.Triggers;
using Thirty.Enum;

public class PlayerCollisionUseCase
{
    private Collider2D _collider;

    private IObservable<CollisionType> _triggerEnterSubject;
    public IObservable<CollisionType> TriggerEnterSubject => _triggerEnterSubject;

    public PlayerCollisionUseCase(Collider2D collider)
    {
        _collider = collider;
        _triggerEnterSubject = new Subject<CollisionType>();
    }

    public void SetObserver()
    {
        _triggerEnterSubject =
            _collider
                .OnTriggerEnter2DAsObservable()
                .Select(x => x.GetComponent<CommonCollisionModel>())
                .Where(x => x != null)
                .Select(x => x.CollisionType);
    }
}
