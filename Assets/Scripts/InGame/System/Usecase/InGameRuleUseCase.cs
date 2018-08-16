using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UniRx;

public class InGameRuleUseCase
{
    private InGameRuleModel _model;

    private bool _isPlay;
    public bool IsPlay => _isPlay;

    public InGameRuleUseCase(InGameRuleModel model)
    {
        _model = model;
    }

    public void StartTimer()
    {
        _model
            .FixedUpdateAsObservable()
            .Subscribe(_ => _model.DecrementLife())
            .AddTo(_model);
    }

    public ReactiveProperty<int> GameTimer()
    {
        return _model.GameLife.Where(life => _isPlay && life > 0).Cast<float, int>().ToReactiveProperty();
    }
}
