using UnityEngine;
using UniRx;

/// <summary>
/// プレイヤーの移動ロジック
/// </summary>
public class PlayerMoveUseCase
{
    private PlayerInputHandler _inputHandler;
    private Vector2 _cachedPlayerAnchorPosition;

    private bool _isValid;

    public PlayerMoveUseCase(PlayerInputHandler inputHandler)
    {
        _inputHandler = inputHandler;

        _isValid = true;
    }

    public void BindMovement(RectTransform player)
    {
        _inputHandler
            .OnBeginDragPosition
            .Where(_ => _isValid)
            .Subscribe(_ => _cachedPlayerAnchorPosition = player.anchoredPosition)
            .AddTo(player.gameObject);

        _inputHandler
            .DragDelta
            .Where(_ => _inputHandler.IsDragging && _isValid)
            .Subscribe(delta => player.anchoredPosition = _cachedPlayerAnchorPosition + delta)
            .AddTo(player.gameObject);
    }

    public void SetValid(bool valid)
    {
        _isValid = valid;
    }
}
