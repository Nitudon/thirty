using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UdonLib.Commons;

/// <summary>
/// インゲームのルールパラメータモデル
/// </summary>
public class InGameRuleModel : InitializableMono
{
    private ReactiveProperty<float> _gameSpeed;
    public IReadOnlyReactiveProperty<float> GameSpeed => _gameSpeed;

    private ReactiveProperty<float> _gameLife;
    public IReadOnlyReactiveProperty<float> GameLife => _gameLife;

    public Subject<Unit> OnGameEnd;

    public override void Initialize()
    {
        _gameSpeed = new ReactiveProperty<float>();
        _gameLife = new ReactiveProperty<float>();

        OnGameEnd = new Subject<Unit>();
    }

    public void DecrementLife()
    {
        _gameLife.Value -= _gameSpeed.Value;
    }

    public void NotifyEndGame()
    {
        OnGameEnd.OnNext(Unit.Default);
    }
}
