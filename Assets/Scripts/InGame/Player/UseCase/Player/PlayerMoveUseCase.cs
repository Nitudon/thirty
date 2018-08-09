﻿using UnityEngine;
using UniRx;

public class PlayerMoveUseCase
{
    private PlayerInputHandler _inputHandler;
    private Vector2 _cachedPlayerAnchorPosition;

    private CompositeDisposable _disposable;

    private bool _isValid;

    public PlayerMoveUseCase(PlayerInputHandler inputHandler)
    {
        _inputHandler = inputHandler;
        _disposable = new CompositeDisposable();

        _isValid = true;
    }

    public void BindMovement(RectTransform player)
    {
        _inputHandler
            .OnBeginDragPosition
            .Where(_ => _isValid)
            .Subscribe(_ => _cachedPlayerAnchorPosition = player.anchoredPosition)
            .AddTo(_disposable)
            .AddTo(player.gameObject);

        _inputHandler
            .DragDelta
            .Where(_ => _inputHandler.IsDragging && _isValid)
            .Subscribe(delta => player.anchoredPosition = _cachedPlayerAnchorPosition + delta)
            .AddTo(_disposable)
            .AddTo(player.gameObject);
    }

    public void SetValid(bool valid)
    {
        _isValid = valid;
    }

    public void Dispose()
    {
        _disposable.Dispose();
    }
}
