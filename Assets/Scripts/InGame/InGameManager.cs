using UdonLib.Commons;
using UnityEngine;

public class InGameManager : UdonBehaviourSingleton<InGameManager>
{
    [SerializeField]
    private InGameRuleModel _ruleModel;
    public InGameRuleModel RuleModel => _ruleModel;

    [SerializeField]
    private InGameCollisionModel _collisionModel;
    public InGameCollisionModel CollisionModel => _collisionModel;

    public override void Initialize()
    {
        _ruleModel.Initialize();
        _collisionModel.Initialize();
        base.Initialize();
    }
}
