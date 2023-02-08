using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonBase<UIManager>
{
    private GameObject scoreText;
    private GameObject moneyText;
    private GameObject levelText;

    public new void Awake()
    {
        base.Awake();
    }
}
