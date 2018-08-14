using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InGameInstaller : MonoInstaller<InGameInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<InGameRuleModel>().AsSingle();
        Container.Bind<InGameCollisionModel>().AsSingle();
    }
}
