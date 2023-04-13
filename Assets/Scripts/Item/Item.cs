using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item : PoolObject
{
    [SerializeField] private TextMeshProUGUI txt_label;
    [SerializeField] private Image icon;
    public ItemType type;
    public int value;

    public Sprite GetIcon() => icon.sprite;
    public void Init(ItemData data)
    {
        icon.sprite = data.sprite;
        value = data.amount + (int)(data.amount * 0.2 * ZoneManager.I.SpinCount);
        txt_label.text = "x " + value;
        type = data.type;

        if (type == ItemType.Bomb)
            txt_label.gameObject.SetActive(false);
    }
    
    public override void OnDeactivate()
    {
        transform.rotation = Quaternion.identity;
        txt_label.gameObject.SetActive(true);
        transform.SetParent(PoolManager.I.transform);
        gameObject.SetActive(false);
    }

    public override void OnSpawn()
    {
        gameObject.SetActive(true);
    }

    public override void OnCreated()
    {
        OnDeactivate();
    }
}
