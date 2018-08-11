using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdonLib.Commons;

public class BlockPresenter : InitializableMono
{
    [SerializeField]
    private BlockView _blockView;

    private CommonCollisionModel _collisionModel;

    public override void Initialize()
    {
        _collisionModel.SetObserver();       
    }
}
