using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour
{
   [SerializeField] public Button btn;

   private void Start()
   {
      btn.onClick.AddListener(HandleButtonClick);
   }

   public abstract void HandleButtonClick();
}
