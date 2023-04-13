using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : ButtonBase
{
    private void Start()
   {
      btn.onClick.AddListener(HandleButtonClick);
   }

   public override void HandleButtonClick()
   {
     UIManager.I.StartGame();
   }
}
