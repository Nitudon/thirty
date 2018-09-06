using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using UdonLib.Commons;

/// <summary>
/// プレイヤーのタッチインプットロジック
/// </summary>
[RequireComponent(typeof(Graphics))]
public class PlayerInputHandler : InitializableMono, ICommonDragHandler
{
    private Subject<Vector2> _onBeginDragPosition;
    public Subject<Vector2> OnBeginDragPosition => _onBeginDragPosition;

    private ReactiveProperty<Vector2> _dragDelta;
    public ReactiveProperty<Vector2> DragDelta => _dragDelta;

    private Subject<Vector2> _onEndDragPosition;
    public Subject<Vector2> OnEndDragPosition => _onEndDragPosition;

    public Vector2 PressPosition{ get; private set; }
    public bool IsDragging { get; private set; }

    public override void Initialize()
    {
        _onBeginDragPosition = new Subject<Vector2>();
        _dragDelta = new ReactiveProperty<Vector2>();
        _onEndDragPosition = new Subject<Vector2>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _onBeginDragPosition.OnNext(eventData.position);
        IsDragging = true;
        PressPosition = eventData.pressPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _dragDelta.Value = eventData.position - eventData.pressPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _onEndDragPosition.OnNext(eventData.position);
        IsDragging = false;
    }
}
