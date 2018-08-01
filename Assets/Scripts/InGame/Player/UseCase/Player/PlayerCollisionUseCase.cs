using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonLib.Commons;
using UniRx;
using UniRx.Triggers;
using Thirty.Enum;

public class PlayerCollisionUseCase : IInitializable<PlayerModel>
{
    private PlayerModel _model;

    private IObservable<CollisionType> _triggerEnterSubject;
    public IObservable<CollisionType> TriggerEnterSubject => _triggerEnterSubject;

    public void Initialize(PlayerModel model)
    {
        _model = model;

        _triggerEnterSubject =
            _model
                .OnTriggerEnter2DAsObservable()
                .Select(x => x.GetComponent<CommonCollisionModel>())
                .Where(x => x != null)
                .Select(x => x.CollisionType);        
    }
}
