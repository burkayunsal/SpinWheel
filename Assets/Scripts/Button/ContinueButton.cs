using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : ButtonBase
{
    public override void HandleButtonClick()
    {
        ZoneManager.I.IncreaseSpinCount();
        ItemSpawner.I.ReplaceItems();
    }

}
