using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UdonLib.Commons;

public class InGameRuleModel : InitializableMono
{
    private ReactiveProperty<float> _gameSpeed;
    public IReadOnlyReactiveProperty<float> GameSpeed => _gameSpeed;

    private ReactiveProperty<float> _gameLife;
    public IReadOnlyReactiveProperty<float> GameLife => _gameLife;

    public override void Initialize()
    {
        _gameSpeed = new ReactiveProperty<float>();
        _gameLife = new ReactiveProperty<float>();
    }

    public void DecrementLife()
    {
        _gameLife.Value -= _gameSpeed.Value;
    }
}
