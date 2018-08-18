using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// インゲーム中で暗黙的依存注入を行うコンポーネントのインストーラ
/// </summary>
public class InGameInstaller : MonoInstaller<InGameInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<InGameRuleModel>().AsSingle();
        Container.Bind<InGameCollisionModel>().AsSingle();
    }
}
