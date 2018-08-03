using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UdonLib.Commons;

public class GameRuleSystemPresenter : MonoBehaviour {

    [SerializeField]
    private List<IInitializable> _initializables;

    [SerializeField]
    private List<IAsyncInitializable> _asyncInitializables;

    private async void Start()
    {
        _initializables.ForEach(x => x.Initialize());
        await Task.WhenAll(_asyncInitializables.Select(x => x.Initialize()));
    }
}
