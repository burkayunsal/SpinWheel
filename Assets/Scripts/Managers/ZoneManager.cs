using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZoneManager : Singleton<ZoneManager>
{
    [SerializeField] private TextMeshProUGUI txtCurrentZone,txtNextSafeZone, txtNextSuperZone;
    [SerializeField] public Button btnTakeLeave;

    private int _spinCount;
    
    private int nextSafeZone, nextSuperZone;
    
    private int safeZoneInterval;
    private int superZoneInterval;
    
    private bool _isSafeZone,_isSuperZone;
    public bool IsSafeZone() => _isSafeZone;
    public bool IsSuperZone() => _isSuperZone;

    [SerializeField] private GameObject silverSpinText, goldenSpinText;
    public int SpinCount
    {
        get => _spinCount;

        set
        {
            _spinCount = value;
            if (_spinCount == nextSuperZone)
            {
                SuperZone();
            }
            else if (_spinCount == nextSafeZone)
            {
                SafeZone();
            }
            else
            {
                _isSafeZone = false;
                SpinManager.I.SetWheelSprite(SpinType.Standart);
                
                if (silverSpinText.activeSelf)
                    silverSpinText.gameObject.SetActive(false);
                
                if (goldenSpinText.activeSelf)
                    goldenSpinText.gameObject.SetActive(false);
            }

            SetTexts();
        }
    }

    private void SuperZone()
    {
        _isSuperZone = true;
        SpinManager.I.SetWheelSprite(SpinType.SuperSpin);
        nextSuperZone += superZoneInterval;
        goldenSpinText.gameObject.SetActive(true);
        btnTakeLeave.gameObject.SetActive(true);
    }

    private void SafeZone()
    {
        _isSafeZone = true;
        SpinManager.I.SetWheelSprite(SpinType.SafeZone);
        nextSafeZone += safeZoneInterval;
                
        if (nextSafeZone == nextSuperZone)
            nextSafeZone += safeZoneInterval;
                
        silverSpinText.gameObject.SetActive(true);
        btnTakeLeave.gameObject.SetActive(true);
    }
    
    private void SetTexts()
    {
        txtCurrentZone.text = SpinCount.ToString();
        txtNextSafeZone.text = nextSafeZone.ToString();
        txtNextSuperZone.text = nextSuperZone.ToString();
    }
    
    private void Start()
    {
        safeZoneInterval = Configs.ZoneSettings.safeZoneInterval;
        superZoneInterval = Configs.ZoneSettings.superZoneInterval;
        
        nextSafeZone = safeZoneInterval;
        nextSuperZone = superZoneInterval;
        
        SpinCount = 1;

        SetTexts();
    }
    
    public void IncreaseSpinCount()
    {
        SpinCount += 1;
        UIManager.I.ToggleTakeOrContinue();
    }
}
