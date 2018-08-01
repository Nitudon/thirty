using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UdonLib.Commons;

public class GameRuleModel : MonoBehaviour, IInitializable
{
    private ReactiveProperty<float> _gameSpeed;
    public IReadOnlyReactiveProperty<float> GameSpeed => _gameSpeed;

    private ReactiveProperty<float> _gameLife;
    public IReadOnlyReactiveProperty<float> GameLife => _gameLife;

    public void Initialize()
    {
        _gameSpeed = new ReactiveProperty<float>();
        _gameLife = new ReactiveProperty<float>();
    }
}
