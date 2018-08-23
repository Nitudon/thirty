using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UdonLib.Commons;
using Thirty.Parameter;

/// <summary>
/// インゲームのルールロジックプレゼンター
/// </summary>
public class InGameRulePresenter : InitializableMono
{
    [SerializeField]
    private InGameRuleView _view;

    private InGameRuleUseCase _useCase;

    private CompositeDisposable _disposable;

    public override void Initialize()
    {
        _useCase = new InGameRuleUseCase();
        _disposable = new CompositeDisposable();
    }

    public void Bind()
    { 
        _useCase
            .GameTimer()
            .Subscribe(x => _view.FillTimerImage(x / SystemConst.GAME_LIFE))
            .AddTo(gameObject)
            .AddTo(_disposable);
    }

    public void Dispose()
    {
        _disposable.Dispose();
    }
}
