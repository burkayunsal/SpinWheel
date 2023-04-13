using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePrizeButton : ButtonBase
{
    public override void HandleButtonClick()
    {
        UIManager.I.ReloadScene();
    }
}
