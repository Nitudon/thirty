using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UdonLib.UI;

public class InGameRuleView : UIMono
{
    [SerializeField]
    private Image _gameTimerFill;

    public void FillTimerImage(float amount)
    {
        _gameTimerFill.fillAmount = amount;
    }
}
