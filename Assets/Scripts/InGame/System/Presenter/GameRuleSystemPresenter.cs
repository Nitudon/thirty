using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UdonLib.Commons;

/// <summary>
/// ゲームシステムの各所システムのプレゼンター
/// </summary>
public class GameRuleSystemPresenter : UdonBehaviour
{
    [SerializeField]
    private List<InitializableMono> _initializables;

    [SerializeField]
    private List<AsyncInitializableMono> _asyncInitializables;

    protected override async void Start()
    {
        _initializables.ForEach(x => x.Initialize());
        await Task.WhenAll(_asyncInitializables.Select(x => x.Initialize()));
    }

    public void StartCoroutineWithSystem(IEnumerator coroutine)
    {
        StartCoroutine(SystemEnumerator(coroutine));
    }

    private IEnumerator SystemEnumerator(IEnumerator coroutine)
    {
        yield return coroutine;
    }
}
