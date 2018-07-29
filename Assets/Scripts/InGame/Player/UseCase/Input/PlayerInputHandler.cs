using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;

public class PlayerInputHandler : IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private readonly Subject<Vector3> _onBeginDragPosition;
    public Subject<Vector3> OnBeginDragPosition => _onBeginDragPosition;

    private readonly ReactiveProperty<Vector3> _dragDelta;
    public ReactiveProperty<Vector3> DragDelta => _dragDelta;

    private readonly Subject<Vector3> _onEndDragPosition;
    public Subject<Vector3> OnEndDragPosition => _onEndDragPosition;

    public PlayerInputHandler()
    {
        _onBeginDragPosition = new Subject<Vector3>();
        _dragDelta = new ReactiveProperty<Vector3>();
        _onEndDragPosition = new Subject<Vector3>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _onBeginDragPosition.OnNext(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _dragDelta.Value = eventData.position - eventData.pressPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _onEndDragPosition.OnNext(eventData.position);
    }
}
