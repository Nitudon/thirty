using UniRx;
using UniRx.Triggers;
using Zenject;

/// <summary>
/// インゲームのルールロジック
/// </summary>
public class InGameRuleUseCase
{
    [Inject]
    private InGameRuleModel _model;

    private bool _isPlay;
    public bool IsPlay => _isPlay;

    public void StartTimer()
    {
        _model
            .FixedUpdateAsObservable()
            .Subscribe(_ => _model.DecrementLife())
            .AddTo(_model);
    }

    public IReadOnlyReactiveProperty<float> GameTimer()
    {
        return _model.GameLife.Where(life => _isPlay && life > 0).ToReactiveProperty();
    }
}
