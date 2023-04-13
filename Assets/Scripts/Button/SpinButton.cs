
using UnityEngine;
using UnityEngine.UI;

public class SpinButton : ButtonBase
{
    [SerializeField] WheelSpinner wheelSpinner;
    public override void HandleButtonClick()
    {
        wheelSpinner.Spin();
    }
}
