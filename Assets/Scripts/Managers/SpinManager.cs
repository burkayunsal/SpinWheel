using UnityEngine;
using UnityEngine.UI;

public class SpinManager : Singleton<SpinManager>
{
    [SerializeField] public BoxCollider2D pinCollider;

    [SerializeField] private Image wheel,pin,spinButton;
    [SerializeField] private Sprite[] wheelSprites,pinSprites;
    [SerializeField] private Sprite btnPressed, btnUnPressed, btnGoldSpin;
    public void SetWheelSprite(SpinType type)
    {
        wheel.sprite = wheelSprites[(int)type];
        pin.sprite = pinSprites[(int)type];
        
        if (type == SpinType.SuperSpin)
            SetSpinButtonGold();
    }

    public void SpinPressed()
    {
        pinCollider.enabled = false;
        spinButton.sprite = btnPressed;
        ZoneManager.I.btnTakeLeave.gameObject.SetActive(false);
    }

    public void SpinEnd()
    {
        pinCollider.enabled = true;
        spinButton.sprite = btnUnPressed;
    }

    public void SetSpinButtonGold()
    {
        spinButton.sprite = btnGoldSpin;
    }
}

public enum SpinType
{
    Standart,
    SafeZone,
    SuperSpin
}
